using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ArrowPrint : MonoBehaviour
{

    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
    }

    // Start is called before the first frame update
    void Start()
    {
        MakeMeshData();
        CreateMesh();
    }

    void MakeMeshData()
    {
        vertices = new Vector3[] { new Vector3(0,0,0), new Vector3(1,0.5f,0), new Vector3(1,-0.5f,0), new Vector3(1, 0.2f, 0), new Vector3(1,-0.2f,0), new Vector3(3, 0.2f, 0), new Vector3(3, -0.2f, 0)};

        triangles = new int[] { 0,1,2,3,5,4,4,5,6 };
    }

    void CreateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
