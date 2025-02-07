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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<CharacterController2D>();
    }

    public void moveForward(){
        horizontalMove = runSpeed;
    }
    public void moveBackward(){
        horizontalMove = -runSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        //horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        anim.SetFloat("speed", Mathf.Abs(rb.linearVelocityX));
        anim.SetFloat("verticalSpeed", rb.linearVelocityY);
        if(Input.GetButtonDown("Jump")){
            jump = true;
        }

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
}
