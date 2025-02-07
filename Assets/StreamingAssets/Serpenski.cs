using UnityEngine;

public class Serpenski : MonoBehaviour
{
    GameObject sierpinskiTriangle; // Reference to the script

    void Start()
    {
        // Find the object with the SierpinskiTriangle script attached
        sierpinskiTriangle = FindObjectOfType<SierpinskiTriangle>().trianglePrefab;
    }
}
