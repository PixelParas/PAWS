using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if Player touches the checkpoint
        {
            PlayerRespawn checkpointSystem = other.GetComponent<PlayerRespawn>();
            if (checkpointSystem != null)
            {
                checkpointSystem.SetCheckpoint(transform.position);
                Debug.Log("Checkpoint set at: " + transform.position);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
