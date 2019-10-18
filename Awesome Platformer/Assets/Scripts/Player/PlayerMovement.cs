﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

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
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
