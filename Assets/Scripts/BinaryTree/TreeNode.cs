using UnityEngine;
using TMPro; // For displaying numbers on nodes

public class TreeNode : MonoBehaviour
{
    public Transform leftChild;  // Left child Transform
    public Transform rightChild; // Right child Transform
    public int nodeNumber; // Unique number assigned to this node
    public LineRenderer lineRenderer;
    public Vector3 initialPosition;
    public float moveSpeed = 0.5f; // Adjust movement speed
    public float moveRange = 0.2f; // Adjust movement range
    public TMP_Text textMesh; // For displaying the number

    public float ID;
    void Start()
    {
        ID = Random.Range(0.0f, 10000.0f);
        // Store the initial position of the node
        initialPosition = transform.position;

        // Setup LineRenderer
        lineRenderer = GetComponent<LineRenderer>();
        textMesh.text = nodeNumber.ToString();
    }

    void Update()
    {
        // Smooth Random Movement using Perlin Noise
        float offsetX = (Mathf.PerlinNoise(Time.time * moveSpeed + ID, 0) - 0.5f) * moveRange;
        float offsetY = (Mathf.PerlinNoise(0, Time.time * moveSpeed + ID) - 0.5f) * moveRange;
        
        transform.position = initialPosition + new Vector3(offsetX, offsetY, 0);

        // Update Line Renderer to connect parent to children
        if (leftChild != null && rightChild != null){
            lineRenderer.SetPosition(1, transform.position);
            lineRenderer.SetPosition(0, leftChild.position);
            lineRenderer.SetPosition(2, rightChild.position);
        }
        else if (leftChild != null){
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, rightChild.position);
            lineRenderer.SetPosition(2, transform.position);
        }
        else if (rightChild != null){
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, leftChild.position);
            lineRenderer.SetPosition(2, transform.position);
        }
    }
    public void SetNodeNumber(int number)
    {
        nodeNumber = number;
        if (textMesh != null)
        {
            textMesh.text = nodeNumber.ToString(); // Update text
        }
    }
}
