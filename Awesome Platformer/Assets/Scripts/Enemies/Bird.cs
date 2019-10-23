using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public GameObject egg;
    public LayerMask playerLayer;

    private Vector3 moveDir = Vector3.left;
    private Vector3 originalPos;
    private Vector3 movePos;
    private bool attacked;
    private bool canMove;
    private float speed = 2.5f;

    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        originalPos.x += 6f;

        movePos = transform.position;
        movePos.x -= 6f;

        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (canMove)
        {
            transform.Translate(moveDir * speed * Time.smoothDeltaTime);

            if (transform.position.x >= originalPos.x)
            {
                moveDir = Vector3.left;
                ChangeDirection(0.5f);
            }
            else if (transform.position.x <= movePos.x)
            {
                moveDir = Vector3.right;
                ChangeDirection(-0.5f);
            }
        }
    }

    private void ChangeDirection(float direction)
    {
        Vector3 tempScale = transform.localScale;
        tempScale.x = direction;
        transform.localScale = tempScale;
    }
}
