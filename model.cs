using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class model : MonoBehaviour
{
    // Start is called before the first frame update
    AddVertices();
    AddIndices();


    List<Vector3> coordinates = new List<Vector3>();
    List<int> dummyIndices = new List<int>();

}
private void AddVertices();

{
    //front
    vertices.Add(new vector3(999, 999, 0.5f));
    vertices.Add(new vector3(-2, 3, 0.5f));
    vertices.Add(new vector3(3, 3, 0.5f));
    vertices.Add(new vector3(-1, 2, 0.5f));
    vertices.Add(new vector3(2, 2, 0.5f));
    vertices.Add(new vector3(-1, 0, 0.5f));
    vertices.Add(new vector3(2, 0, 0.5f));
    vertices.Add(new vector3(-1, -1, 0.5f));
    vertices.Add(new vector3(-2, 3, 0.5f));
    vertices.Add(new vector3(1, -1, 0.5f));
    vertices.Add(new vector3(-2, -4, 0.5f));
    vertices.Add(new vector3(-1, -4, 0.5f));
    vertices.Add(new vector3(-2, 3, 0.5f));

    //back
    vertices.Add(new vector3(3, 3, -0.5f));
    vertices.Add(new vector3(-1, 2, -0.5f));
    vertices.Add(new vector3(2, 2, -0.5f));
    vertices.Add(new vector3(-1, 0, -0.5f));
    vertices.Add(new vector3(2, 0, -0.5f));
    vertices.Add(new vector3(1, -1, -0.5f));
    vertices.Add(new vector3(-2, -4, -0.5f));
    vertices.Add(new vector3(-1, -4, -0.5f));
    vertices.Add(new vector3(-2, 3, -0.5f));

}

private void AddIndices();
{
    Indices.Add(new int(0));
    Indices.Add(new int(1));//front1
    Indices.Add(new int(2));
    //+
    Indices.Add(new int(2));
    Indices.Add(new int(3));//from2
    Indices.Add(new int(1));

    Indices.Add(new int(2));
    Indices.Add(new int(5));//front3
    Indices.Add(new int(4));
    ///+
    Indices.Add(new int(4));
    Indices.Add(new int(6));//front4
    Indices.Add(new int(5));

    Indices.Add(new int(7));
    Indices.Add(new int(10));//front5
    Indices.Add(new int(8));
    //+
    Indices.Add(new int(9));
    Indices.Add(new int(8));//front6
    Indices.Add(new int(7));
}

}
