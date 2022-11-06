using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class model : MonoBehaviour
{

    internal List<Vector3> vertices = new List<Vector3>();
    internal List<Vector3Int> faces = new List<Vector3Int>();
    internal List<Vector2> textureCoordinates = new List<Vector2>();
    internal List<Vector3Int> textureIndexList = new List<Vector3Int>();
    internal List<Vector3> normals = new List<Vector3>();

    public model()
    {
        AddVertices();
        AddFaces();
        //AddNormals();
    }


    public GameObject CreateUnityGameObject()

    {

        Mesh mesh = new Mesh();

        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();

        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();


        List<Vector3> coords = new List<Vector3>();

        List<int> dummy_indices = new List<int>();

        List<Vector2> text_coords = new List<Vector2>();

        List<Vector3> normalz = new List<Vector3>();



        for (int i = 0; i < faces.Count; i++)

        {

            // Vector3 normal_for_face = normals[i / 3];

            // normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3); //text_coords.Add(_texture_coordinates[_texture_index_list[i].x]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 1); ///text_coords.Add(_texture_coordinates[_texture_index_list[i].y]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 2); //text_coords.Add(_texture_coordinates[_texture_index_list[i].z]); normalz.Add(normal_for_face);

        }



        mesh.vertices = coords.ToArray();

        mesh.triangles = dummy_indices.ToArray();

        mesh.uv = text_coords.ToArray();

        mesh.normals = normalz.ToArray(); ;



        mesh_filter.mesh = mesh;

        return newGO;
    }

    private void AddVertices()
    {

        // Front
        vertices.Add(new Vector3(-2, -4, 0.5f));
        vertices.Add(new Vector3(-2, 3, 0.5f));//f0
        vertices.Add(new Vector3(-1, -4, 0.5f));

        vertices.Add(new Vector3(-1, -4, 0.5f));
        vertices.Add(new Vector3(-2, 3, 0.5f));//f1
        vertices.Add(new Vector3(-1, 2, 0.5f));

        vertices.Add(new Vector3(-1, -1, 0.5f));
        vertices.Add(new Vector3(-1, 0, 0.5f));//f2
        vertices.Add(new Vector3(1, -1, 0.5f));

        vertices.Add(new Vector3(2, 0, 0.5f));
        vertices.Add(new Vector3(1, -1, 0.5f));//f3
        vertices.Add(new Vector3(-1, 0, 0.5f));

        vertices.Add(new Vector3(-2, 3, 0.5f));
        vertices.Add(new Vector3(-1, 2, 0.5f));//f4
        vertices.Add(new Vector3(2, 2, 0.5f));

        vertices.Add(new Vector3(-2, 3, 0.5f));
        vertices.Add(new Vector3(3, 3, 0.5f));//f5
        vertices.Add(new Vector3(2, 2, 0.5f));



        //back
        vertices.Add(new Vector3(-2, -4, -0.5f));
        vertices.Add(new Vector3(-2, 3, -0.5f));//f0
        vertices.Add(new Vector3(-1, -4, -0.5f));

        vertices.Add(new Vector3(-1, -4, -0.5f));
        vertices.Add(new Vector3(-2, 3, -0.5f));//f1
        vertices.Add(new Vector3(-1, 2, -0.5f));

        vertices.Add(new Vector3(-1, -1, -0.5f));
        vertices.Add(new Vector3(-1, 0, -0.5f));//f2
        vertices.Add(new Vector3(1, -1, -0.5f));

        vertices.Add(new Vector3(2, 0, -0.5f));
        vertices.Add(new Vector3(1, -1, -0.5f));//f3
        vertices.Add(new Vector3(-1, 0, -0.5f));

        vertices.Add(new Vector3(-2, 3, -0.5f));
        vertices.Add(new Vector3(-1, 2, -0.5f));//f4
        vertices.Add(new Vector3(2, 2, -0.5f));

        vertices.Add(new Vector3(-2, 3, -0.5f));
        vertices.Add(new Vector3(3, 3, -0.5f));//f5
        vertices.Add(new Vector3(2, 2, -0.5f));
    }

    private void AddFaces()
    {
        // Front
        faces.Add(new Vector3Int(0, 6, 8));//f0
        faces.Add(new Vector3Int(1, 6, 0));//f1

        faces.Add(new Vector3Int(4, 2, 3));//f2
        faces.Add(new Vector3Int(3, 4, 5));//f3

        faces.Add(new Vector3Int(8, 7, 6));//f4
        faces.Add(new Vector3Int(8, 9, 7));//f5

        //back
        faces.Add(new Vector3Int(16, 10, 18));
        faces.Add(new Vector3Int(11, 16, 10));

       faces.Add(new Vector3Int(13, 14, 12));
        faces.Add(new Vector3Int(13, 15, 14));

        faces.Add(new Vector3Int(16, 18, 17));
        faces.Add(new Vector3Int(19, 17, 18));
        
        //left
        faces.Add(new Vector3Int(10, 18, 8));
        faces.Add(new Vector3Int(8, 10, 0));

        //right
        faces.Add(new Vector3Int(1, 2, 11));
        faces.Add(new Vector3Int(12, 2, 11));
        faces.Add(new Vector3Int(3, 5, 13));
        faces.Add(new Vector3Int(15, 5, 13));
        faces.Add(new Vector3Int(4, 14, 6));
        faces.Add(new Vector3Int(16, 14, 6));
        faces.Add(new Vector3Int(7, 17, 19));
        faces.Add(new Vector3Int(19, 9, 17));

        //top
        faces.Add(new Vector3Int(9, 8, 19));
        faces.Add(new Vector3Int(18, 8, 19));

        //bottom
        faces.Add(new Vector3Int(0, 10, 1));
        faces.Add(new Vector3Int(11, 1, 0));
        faces.Add(new Vector3Int(2, 3, 12));
        faces.Add(new Vector3Int(13, 3, 12));
        faces.Add(new Vector3Int(5, 3, 15));
        faces.Add(new Vector3Int(13, 3, 15));
        faces.Add(new Vector3Int(6, 7, 17));
        faces.Add(new Vector3Int(16, 6, 17));
        faces.Add(new Vector3Int(7, 9, 19));
        faces.Add(new Vector3Int(17, 7, 19));
        

    }

}

