using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class model : MonoBehaviour
{
    // Start is called before the first frame update
    AddVertices();
    AddFaces();


    List<Vector3> coordinates = new List<Vector3>();

}
    private void AddVertices()

{
    //front
    veretices.Add(new vertor3(999, 999, 0.5f));
    veretices.Add(new vertor3(-2, 3, 0.5f));
    veretices.Add(new vertor3(3, 3, 0.5f));
    veretices.Add(new vertor3(-1, 2, 0.5f));
    veretices.Add(new vertor3(2, 2, 0.5f));
    veretices.Add(new vertor3(-1, 0, 0.5f));
    veretices.Add(new vertor3(2, 0, 0.5f));
    veretices.Add(new vertor3(-1, -1, 0.5f));
    veretices.Add(new vertor3(-2, 3, 0.5f));
    veretices.Add(new vertor3(1, -1, 0.5f));
    veretices.Add(new vertor3(-2, -4, 0.5f));
    veretices.Add(new vertor3(-1, -4, 0.5f));
    veretices.Add(new vertor3(-2, 3, 0.5f));

    //back
    veretices.Add(new vertor3(3, 3, -0.5f));
    veretices.Add(new vertor3(-1, 2, -0.5f));
    veretices.Add(new vertor3(2, 2, -0.5f));
    veretices.Add(new vertor3(-1, 0, -0.5f));
    veretices.Add(new vertor3(2, 0, -0.5f));
    veretices.Add(new vertor3(1, -1, -0.5f));
    veretices.Add(new vertor3(-2, -4, -0.5f));
    veretices.Add(new vertor3(-1, -4, -0.5f));
    veretices.Add(new vertor3(-2, 3, -0.5f));




}
}
