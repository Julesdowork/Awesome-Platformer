using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    private bool isGrounded;
    private bool jumped;
    private float jumpPower = 5f;

    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CheckIfGrounded();
        PlayerJump();
    }

    void FixedUpdate()
    {
        PlayerWalk();
    }

    private void PlayerWalk()
    {
        float h = Input.GetAxisRaw("Horizontal");
        
        if (h > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            ChangeDirection(1);
        }
        else if (h < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            ChangeDirection(-1);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        anim.SetInteger("Speed", Mathf.Abs((int) rb.velocity.x));
    }

    private void ChangeDirection(int direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }

    private void CheckIfGrounded()
    {
        isGrounded = Physics2D.Raycast(groundCheckPos.position, Vector2.down,
            0.1f, groundLayer);

        if (isGrounded)
        {
            // and we jumped before
            if (jumped)
            {
                jumped = false;

                anim.SetBool("Jump", false);
            }
        }
    }

    private void PlayerJump()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                jumped = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);

                anim.SetBool("Jump", true);
            }
        }
    }
}
