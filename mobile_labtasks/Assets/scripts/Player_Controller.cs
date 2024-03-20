using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator anim;
    public float playerSpeed = 5.0f;
    public float horizontalInput;

    private bool isFacingRight = true;
    private bool isWalking;
    private bool isIdle;

    private bool isGrounded = true;
    public float jumpForce = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > 0)
        {
            isWalking = true;
            transform.Translate(Vector2.right * Time.deltaTime * playerSpeed * horizontalInput);
        }
        else if (horizontalInput < 0)
        {
            isWalking = true;
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed * horizontalInput);
        }
        else if (horizontalInput == 0)
        {
            isWalking = false;
        }
    }

    private void AnimationController()
    {
        if (isWalking == true)
        {
            anim.SetInteger("Animation", 1);
        }
        else
        {
            anim.SetInteger("Animation", 0);
        }
    }

    private void MovementDirection()
    {
        if (isFacingRight && horizontalInput < 0)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        else if (!isFacingRight && horizontalInput > 0)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0.0f, 180.0f, 0.0f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

    void Update()
    {
        MovePlayer();
        MovementDirection();
        AnimationController();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        { 
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
            anim.SetInteger("Animation", 2);
        }
    }

    //public void walk()
    //{
    //    anim.SetInteger("Animation", 1);
    //}

    //public void idle()
    //{
    //   anim.SetInteger("Animation", 0);
    //}

    //public void jump()
    //{
    //    anim.SetInteger("Animation", 2);
    //}

}