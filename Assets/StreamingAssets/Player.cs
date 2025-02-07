using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement player;
    // Start is called once when you Run
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        player.MoveForward();
    }
}
