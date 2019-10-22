using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform groundCheckPos;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Physics2D.Raycast(groundCheckPos.position, Vector2.down, 0.5f, groundLayer))
        {
            print("Collided with ground");
        }
    }

    void FixedUpdate()
    {
        PlayerWalk();
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        //if (target.gameObject.CompareTag("Ground"))
        //    print("Collided with the ground");
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        //if (target.CompareTag("Ground"))
        //    print("Collided with the ground");
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
}
