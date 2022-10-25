using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class PipeLine : MonoBehaviour
{
    List<Vector3> verts;
    float angle;
    Vector3 axis;
    Vector3 scale;
    Vector3 translation;

    Vector3 camPos;
    Vector3 camLookAt;
    Vector3 camUp;

    Matrix4x4 transformMatrix;
    Matrix4x4 viewingMatrix;
    Matrix4x4 projectionMatrix;

  




    void Start()
    {



        model my_Model = new model();

        verts = my_Model.vertices;
        my_Model.CreateUnityGameObject();

        print_verts(verts);


        Vector3 axis = new Vector3(-2, 1, 1);
        axis.Normalize();


        Matrix4x4 rotation_matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.AngleAxis(-25, axis), Vector3.one);
        print_matrix(rotation_matrix);

        List<Vector3> image_after_rotation = get_image(verts, rotation_matrix);
        print_verts(image_after_rotation);


        angle = -44;
        scale = new Vector3(4, 1, 2);
        Matrix4x4 scaleMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, scale);
        List<Vector3> imageAfterScale = get_image(image_after_rotation, scaleMatrix);
        print_scale(imageAfterScale);



        translation = new Vector3(1, -5, 1);
        Matrix4x4 translationMatrix = Matrix4x4.TRS(translation, Quaternion.identity, Vector3.one);
        List<Vector3> imageAfterTranslation = get_image(imageAfterScale, translationMatrix);



        Matrix4x4 transformMatrix = translationMatrix * scaleMatrix * rotation_matrix;
        List<Vector3> imageAfterTransform = get_image(my_Model.vertices, transformMatrix);

        camPos = new Vector3(16, 3, 50);
        camLookAt = new Vector3(0, 4, 2);
        camUp = new Vector3(1, 0, 14);
        Matrix4x4 viewMatrix = Matrix4x4.LookAt(camPos, camLookAt, camUp);
        List<Vector3> imageAfterViewing = get_image(imageAfterTransform, viewMatrix);

        Matrix4x4 everythingMatrix = projectionMatrix * viewingMatrix * transformMatrix;
        List<Vector3> imageAfterEverything = get_image(my_Model.vertices, everythingMatrix);

        Matrix4x4 ProjectionMatrix = Matrix4x4.Perspective(90, 1, 1, 1000);
        List<Vector3> imageAfterProjection = get_image(imageAfterViewing, ProjectionMatrix);

        List<Vector2> projectionByHand = new List<Vector2>();
        foreach (Vector3 v in imageAfterViewing)
        {
            projectionByHand.Add(new Vector2(v.x / v.z, v.y / v.z));
        }




        /*   print_matrix(rotation_matrix);
           print_verts(image_after_rotation);
           print_matrix(scaleMatrix);
           print_verts(imageAfterScale);
           print_matrix(translationMatrix);
           print_verts(imageAfterTranslation);
           print_matrix(transformMatrix);
           print_verts(imageAfterTransform);
           print_matrix(viewMatrix);
           print_verts(imageAfterViewing);
           print(everythingMatrix);
           print_verts(imageAfterEverything);
           print_matrix(ProjectionMatrix);
           print_verts(imageAfterProjection);
           print_file2d(projectionByHand); */



        outcode start = new outcode(new Vector2(0.1f, 1.2f));

        outcode end = new outcode(new Vector2(0.6f, -1.2f));

    }

    bool line_clip(ref Vector2 start, ref Vector2 end)
    {
        outcode startOutcode = new outcode(start);
        outcode endOutcode = new outcode(end);

        outcode inScreen = new outcode();
            if ((startOutcode + endOutcode) == inScreen) 
            return true;
        if ((startOutcode * endOutcode) != inScreen)
            return false;

    }


    List<Vector2> intersectEdge(Vector2 start, Vector2 end, outcode pointOutcode)
    {
        float m = (end.y - start.y) / (end.x - start.x);//slope
        List<Vector2> intersections = new List<Vector2>();
        if(pointOutcode.up)
        {
            intersections.Add(new Vector2( start.x  + (1/m)*(1 - start.y),1));
        }

        if (pointOutcode.down)
        {
            intersections.Add(new Vector2(start.x + (1 / m) * (-1 - start.y), -1));
        }

        if (pointOutcode.left)
        {
            intersections.Add(new Vector2 (-1, start.y + m *(-1 - start.x)));
        }

        if (pointOutcode.right)
        {
            intersections.Add(new Vector2(1, start.y + m * (1 - start.x)));
        }
        return intersections;
    }
 
    private List<Vector3> get_image(List<Vector3> list_verts, Matrix4x4 transform_matrix)
    {
        List<Vector3> img_verts = new List<Vector3>();

        foreach (Vector3 v in list_verts)
        {
            Vector4 v2 = new Vector4(v.x, v.y, v.z, 1);
            img_verts.Add(transform_matrix * v);
        }
        return img_verts;

    }

    private void print_matrix(Matrix4x4 matrix)
    {
        string path = "Assets/matrix.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);

        for (int i = 0; i < 4; i++)
        {
            Vector4 row = matrix.GetRow(i);
            writer.WriteLine(row.x.ToString() + "   ,   " + row.y.ToString() + "   ,   " + row.z.ToString() + "   ,   " + row.w.ToString());


        }

        writer.Close();

    }

    private void print_verts(List<Vector3> v_list)
    {
        string path = "Assets/vertices.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        foreach (Vector3 v in v_list)
        {
            writer.WriteLine(v.x.ToString() + "   ,   " + v.y.ToString() + "   ,   " + v.z.ToString() + "   ,   ");

        }
        writer.Close();
    }
    private void print_file2d(List<Vector2> points2d)
    {
        string path = "Assets/2d.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        foreach (Vector2 v in points2d)
        {
            writer.WriteLine(v.x + "    ,   " + v.y);

        }
        writer.Close();
    }

    private void print_scale(List<Vector3> scale)
    {
        string path = "Assets/scale.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        foreach (Vector3 v in scale)
        {
            writer.WriteLine(v.x + "    ,   " + v.y);

        }
        writer.Close();
    }

   

}

