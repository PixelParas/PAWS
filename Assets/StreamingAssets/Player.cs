using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMovement player;
    // Start is called once when you Run
    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        player.Jump();
    }
}