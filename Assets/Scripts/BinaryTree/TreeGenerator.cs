using UnityEngine;

public class TreeGenerator : MonoBehaviour
{
    public GameObject treeNodePrefab; // Assign a prefab with TreeNode.cs attached
    public int?[] treeArray = { 1, 2, 3, 7, 5, 8, 4 }; // Example binary tree
    private Transform[] createdNodes;

    public float xSpacing = 2.0f; // Horizontal spacing
    public float ySpacing = 2.5f; // Vertical spacing

    void Start()
    {
        if (treeNodePrefab == null)
        {
            Debug.LogError("Tree Node Prefab is missing!");
            return;
        }

        createdNodes = new Transform[treeArray.Length];
        //BuildTree();
    }

    public void createNode(int i){
        Vector3 position = CalculatePosition(i);
        GameObject node = Instantiate(treeNodePrefab, position, Quaternion.identity);
        node.name = "Node " + treeArray[i];

        TreeNode treeNode = node.GetComponent<TreeNode>();
        treeNode.SetNodeNumber(treeArray[i].Value);
        createdNodes[i] = node.transform;
        Debug.Log(i.ToString()+ " ," + node.name);
        if(i == 2 || i == 6 || i == 14){
            generateLinks(i+1);
        }
    }
    public void generateLinks(int max){
        for (int i = 0; i < max; i++)
        {
            if (createdNodes[i] != null)
            {
                int leftIndex = 2 * i + 1;
                int rightIndex = 2 * i + 2;

                TreeNode treeNode = createdNodes[i].GetComponent<TreeNode>();

                if (leftIndex < max && createdNodes[leftIndex] != null)
                {
                    treeNode.leftChild = createdNodes[leftIndex];
                }
                if (rightIndex < max && createdNodes[rightIndex] != null)
                {
                    treeNode.rightChild = createdNodes[rightIndex];
                }
            }
        }
    }
    void BuildTree()
    {
        for (int i = 0; i < treeArray.Length; i++)
        {
            if (treeArray[i] != null)
            {
                Vector3 position = CalculatePosition(i);
                GameObject node = Instantiate(treeNodePrefab, position, Quaternion.identity);
                node.name = "Node " + treeArray[i];

                TreeNode treeNode = node.GetComponent<TreeNode>();
                treeNode.SetNodeNumber(treeArray[i].Value);
                createdNodes[i] = node.transform;
            }
        }

        for (int i = 0; i < treeArray.Length; i++)
        {
            if (createdNodes[i] != null)
            {
                int leftIndex = 2 * i + 1;
                int rightIndex = 2 * i + 2;

                TreeNode treeNode = createdNodes[i].GetComponent<TreeNode>();

                if (leftIndex < treeArray.Length && createdNodes[leftIndex] != null)
                {
                    treeNode.leftChild = createdNodes[leftIndex];
                }
                if (rightIndex < treeArray.Length && createdNodes[rightIndex] != null)
                {
                    treeNode.rightChild = createdNodes[rightIndex];
                }
            }
        }
    }

    Vector3 CalculatePosition(int index)
    {
        int level = (int)Mathf.Floor(Mathf.Log(index + 1, 2)); // Determine the depth level
        int positionInLevel = index - ((1 << level) - 1); // Determine position in that level

        float xPos = (positionInLevel - Mathf.Pow(2, level - 1) + 0.5f) * xSpacing * Mathf.Pow(0.5f, level);
        float yPos = -level * ySpacing; // Move down for each level

        return new Vector3(xPos, yPos, 0);
    }
}
