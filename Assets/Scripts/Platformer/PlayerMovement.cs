using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Animator anim;
    public Rigidbody2D rb;

public LayerMask obstacleLayer;
public float checkDistance;
    public float distanceToWall;
    public   float distanceToHole;

    public Transform head;
    public Transform knees;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController2D>();
    }

    public void MoveForward(){
        horizontalMove = runSpeed;
    }
    public void MoveBackward(){
        horizontalMove = -runSpeed;
    }
    public void Stop(){
        horizontalMove = 0;
    }
    public void Jump(){
        jump = true;
    }
    // Update is called once per frame
    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        anim.SetFloat("speed", Mathf.Abs(rb.linearVelocityX));
        anim.SetFloat("verticalSpeed", rb.linearVelocityY);
CheckDistances();   
        /*if(Input.GetButtonDown("Jump")){
            jump = true;
        }*/

        if(Input.GetKeyDown(KeyCode.C)){
            crouch = true;
        }
        if(Input.GetKeyUp(KeyCode.C)){
            crouch=false;
        }
    }

    void FixedUpdate(){
        controller.Move(horizontalMove*Time.fixedDeltaTime,crouch,jump);
        jump=false;

    }

    public void isCrouching(bool isCrouching){
        anim.SetBool("IsCrouching", isCrouching);
    }

    void CheckDistances()
    {
        // Cast a ray from the head to detect a wall
        RaycastHit2D wallHit = Physics2D.Raycast(head.position, transform.right);
        RaycastHit2D holeHit = Physics2D.Raycast(knees.position, transform.right);
        distanceToWall = wallHit.distance;
        distanceToHole = holeHit.distance;
        // Debugging rays (optional)
        Debug.DrawRay(head.position, transform.right * checkDistance, Color.red);  // Ray for wall detection
        Debug.DrawRay(knees.position, transform.right * checkDistance, Color.blue); // Ray for hole detection
    }

}
