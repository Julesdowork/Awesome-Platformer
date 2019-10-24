using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    private Vector3 moveDir = Vector3.down;
    private string coroutineName = "ChangeMovement";
    private Animator anim;
    private Rigidbody2D rb;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coroutineName);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag(MyTags.BULLET_TAG))
        {
            anim.Play("SpiderDead");
            rb.bodyType = RigidbodyType2D.Dynamic;
            StartCoroutine(Die());
            StopCoroutine(coroutineName);
        }
    }

    private void Move()
    {
        transform.Translate(moveDir * Time.smoothDeltaTime);
    }

    IEnumerator ChangeMovement()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        if (moveDir == Vector3.down)
        {
            moveDir = Vector3.up;
        }
        else
        {
            moveDir = Vector3.down;
        }

        StartCoroutine(coroutineName);
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}
