using UnityEngine;
using System.Collections;

public class BinaryTree : MonoBehaviour
{
    private TreeGenerator tree;
    public float delayBetweenNodes = 0.2f; // Time delay between node creations

    void Start()
    {
        tree = GetComponent<TreeGenerator>();
        StartCoroutine(SpawnTreeWithDelay());
    }

    IEnumerator SpawnTreeWithDelay()
    {
        for (int i = 0; i < tree.treeArray.Length; i++)
        {
            tree.createNode(i); // Create one node
            yield return new WaitForSeconds(delayBetweenNodes); // Wait before creating the next node
        }
    }
}