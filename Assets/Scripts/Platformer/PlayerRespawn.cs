using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 respawnPoint; // Stores the last checkpoint position
    public float fallThreshold = -10f; // Height where player is considered "dead"

    void Start()
    {
        // Set initial spawn point
        respawnPoint = transform.position;
    }

    void Update()
    {
        // Check if player falls below threshold
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        respawnPoint = newCheckpoint;
    }

    void Respawn()
    {
        transform.position = respawnPoint;
        Debug.Log("Player respawned at: " + respawnPoint);
    }
}