using UnityEngine;
using System.Collections.Generic;

public class SierpinskiTriangle : MonoBehaviour
{
    public GameObject trianglePrefab; // Assign in Inspector
    public int depth = 3; // Set depth in Inspector
    private List<GameObject> triangles = new List<GameObject>();

    void Start()
    {
      //  GenerateTriangle();
    }

    void GenerateTriangle()
    {
        ClearTriangles();
        Vector3 p1 = new Vector3(0, 1, 0);
        Vector3 p2 = new Vector3(-1, -1, 0);
        Vector3 p3 = new Vector3(1, -1, 0);
        
        GenerateRecursive(p1, p2, p3, depth, 1.0f);
    }

    void GenerateRecursive(Vector3 p1, Vector3 p2, Vector3 p3, int depth, float scale)
    {
        if (depth == 0)
        {
            SpawnTriangle(p1, p2, p3, scale*2.0f);
            return;
        }
        
        Vector3 mid1 = (p1 + p2) / 2;
        Vector3 mid2 = (p2 + p3) / 2;
        Vector3 mid3 = (p1 + p3) / 2;
        
        float newScale = scale / 2.0f;
        
        GenerateRecursive(p1, mid1, mid3, depth - 1, newScale);
        GenerateRecursive(mid1, p2, mid2, depth - 1, newScale);
        GenerateRecursive(mid3, mid2, p3, depth - 1, newScale);
    }

    void SpawnTriangle(Vector3 p1, Vector3 p2, Vector3 p3, float scale)
    {
        GameObject triangle = Instantiate(trianglePrefab, transform);
        triangle.transform.position = (p1 + p2 + p3) / 3; // Centered position
        triangle.transform.localScale = new Vector3(scale, scale, scale);
        triangles.Add(triangle);
    }

    void ClearTriangles()
    {
        foreach (var tri in triangles)
        {
            Destroy(tri);
        }
        triangles.Clear();
    }
}