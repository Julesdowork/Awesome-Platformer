using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform downCollision, leftCollision, rightCollision, topCollision;
    public LayerMask playerLayer;

    private bool moveLeft;
    private bool canMove;
    private bool stunned;
    private Vector3 leftColPos, rightColPos;
    
    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // store default collision positions in these Vector3s
        leftColPos = leftCollision.localPosition;
        rightColPos = rightCollision.localPosition;
    }

    // Start is called before the first frame update
    void Start()
    {
        moveLeft = true;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (moveLeft)
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            else
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
      
        CheckCollision();
    }

    private void CheckCollision()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(leftCollision.position, Vector2.left, 0.1f, playerLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(rightCollision.position, Vector2.right, 0.1f, playerLayer);

        Collider2D topHit = Physics2D.OverlapCircle(topCollision.position, 0.2f, playerLayer);

        if (topHit != null)
        {
            if (topHit.gameObject.CompareTag("Player"))
            {
                if (!stunned)
                {
                    topHit.gameObject.GetComponent<Rigidbody2D>().velocity =
                        new Vector2(topHit.gameObject.GetComponent<Rigidbody2D>().velocity.x, 7f);

                    canMove = false;
                    rb.velocity = new Vector2(0, 0);
                    
                    anim.Play("SnailStunned");
                    stunned = true;

                    // BEETLE CODE HERE
                }
            }
        }

        if (leftHit)
        {
            if (leftHit.collider.gameObject.CompareTag(MyTags.PLAYER_TAG))
            {
                if (!stunned)
                {
                    // Apply damage to player
                    print("Damage left");
                }
                else
                {
                    rb.velocity = new Vector2(15f, rb.velocity.y);
                }
            }
        }

        if (rightHit)
        {
            if (rightHit.collider.gameObject.CompareTag(MyTags.PLAYER_TAG))
            {
                if (!stunned)
                {
                    // Apply damage to player
                    print("Damage right");
                }
                else
                {
                    rb.velocity = new Vector2(-15f, rb.velocity.y);
                }
            }
        }

        // if we don't detect collision anymore, do this...
        if (!Physics2D.Raycast(downCollision.position, Vector2.down, 0.1f))
            ChangeDirection();
    }

    private void ChangeDirection()
    {
        moveLeft = !moveLeft;

        Vector3 tempScale = transform.localScale;

        if (moveLeft)
        {
            tempScale.x = Mathf.Abs(tempScale.x);

            // use default collision positions to keep collision points from switching
            // when Snail changes direction
            leftCollision.localPosition = leftColPos;
            rightCollision.localPosition = rightColPos;
        }
        else
        {
            tempScale.x = -Mathf.Abs(tempScale.x);

            // use default collision positions to keep collision points from switching
            // when Snail changes direction
            leftCollision.localPosition = rightColPos;
            rightCollision.localPosition = leftColPos;
        }

        transform.localScale = tempScale;
    }
}
