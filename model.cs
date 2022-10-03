using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class model : MonoBehaviour
{

    List<int> faces;


    internal List<Vector3> vertices = new List<Vector3>();


    public model()
    {
        AddVertices();
        AddFaces();
    }


    private void AddVertices()

{
    //front
   // vertices.Add(new Vector3(999, 999, 0.5f));
    vertices.Add(new Vector3(-2, 3, 0.5f));
    vertices.Add(new Vector3(3, 3, 0.5f));
    vertices.Add(new Vector3(-1, 2, 0.5f));
    vertices.Add(new Vector3(2, 2, 0.5f));
    vertices.Add(new Vector3(-1, 0, 0.5f));
    vertices.Add(new Vector3(2, 0, 0.5f));
    vertices.Add(new Vector3(-1, -1, 0.5f));
    vertices.Add(new Vector3(-2, 3, 0.5f));
    vertices.Add(new Vector3(1, -1, 0.5f));
    vertices.Add(new Vector3(-2, -4, 0.5f));
    vertices.Add(new Vector3(-1, -4, 0.5f));
    vertices.Add(new Vector3(-2, 3, 0.5f));

        //back
        vertices.Add(new Vector3(-2, 3, -0.5f));
        vertices.Add(new Vector3(3, 3, -0.5f));
        vertices.Add(new Vector3(-1, 2, -0.5f));
        vertices.Add(new Vector3(2, 2, -0.5f));
        vertices.Add(new Vector3(-1, 0, -0.5f));
        vertices.Add(new Vector3(2, 0, -0.5f));
        vertices.Add(new Vector3(-1, -1,- 0.5f));
        vertices.Add(new Vector3(-2, 3,- 0.5f));
        vertices.Add(new Vector3(1, -1,- 0.5f));
        vertices.Add(new Vector3(-2, -4,- 0.5f));
        vertices.Add(new Vector3(-1, -4, -0.5f));
        vertices.Add(new Vector3(-2, 3, -0.5f));

    }


private void AddFaces()
{
        faces = new List<int>();
    faces.Add(0);
    faces.Add(1);//front0
    faces.Add(2);
    //+
    
    faces.Add(3);
    faces.Add(1);//from1
    faces.Add(2);

        faces.Add(2);
        faces.Add(4);//front2
        faces.Add(5);
        ///+
        faces.Add(4);
        faces.Add(5);//front3
        faces.Add(6);

        faces.Add(10);
        faces.Add(8);//front4
        faces.Add(7);
        //+
        faces.Add(8);
        faces.Add(8);//front5
        faces.Add(9);

    }



internal GameObject CreateUnityGameObject()

    {

    Mesh mesh = new Mesh();

    GameObject newGO = new GameObject();

    MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();

    MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();




    List<Vector3> coords = new List<Vector3>();

    List<int> dummy_indices = new List<int>();

    List<Vector2> text_coords = new List<Vector2>();

    List<Vector3> normalz = new List<Vector3>();



    for (int i = 0; i < faces.Count; i+=3)

    {

      //  Vector3 normal_for_face = normals[i / 3];

       // normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

        coords.Add(vertices[faces[i]]); dummy_indices.Add(i );// text_coords.Add(_texture_coordinates[_texture_index_list[i].x]); normalz.Add(normal_for_face);

        coords.Add(vertices[faces[i+1]]); dummy_indices.Add(i + 1);// text_coords.Add(_texture_coordinates[_texture_index_list[i].y]); normalz.Add(normal_for_face);

        coords.Add(vertices[faces[i+2]]); dummy_indices.Add(i + 2); //text_coords.Add(_texture_coordinates[_texture_index_list[i].z]); normalz.Add(normal_for_face);

    }



    mesh.vertices = coords.ToArray();

    mesh.triangles = dummy_indices.ToArray();

    mesh.uv = text_coords.ToArray();

    mesh.normals = normalz.ToArray(); ;



    mesh_filter.mesh = mesh;

    return newGO;



}


}


