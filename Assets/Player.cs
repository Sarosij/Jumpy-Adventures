using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    [Header("Move info")]
    public float moveSpeed;
    public float jumpForce;
    

    private bool canDoubleJump;


    private float movingInput;

    [Header("Collision info")]
    public LayerMask whatIsGround;
    public float groundCheckDistance;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = rb.velocity.x != 0;

        anim.SetBool("isMoving", isMoving);

        CollisionChecks();

        InputChecks();

        if (isGrounded)
        {
            canDoubleJump = true;
        }

        Move();
    }

    private void InputChecks()
    {
        movingInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpButton();

        }
    }

    private void JumpButton()
    {
        if (isGrounded)
        {
            Jump();
        }
        else if (canDoubleJump){

            canDoubleJump = false;
            Jump();
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveSpeed * movingInput, rb.velocity.y);
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, whatIsGround);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine (transform.position, new Vector3(transform.position.x, transform.position.y - groundCheckDistance));    
    }
}