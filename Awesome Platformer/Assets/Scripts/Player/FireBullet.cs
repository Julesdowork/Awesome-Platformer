using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    private float speed = 10f;
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    private bool canMove;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        StartCoroutine(DisableBullet(5f));
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag(MyTags.BEETLE_TAG) || target.CompareTag(MyTags.SNAIL_TAG)
            || target.CompareTag(MyTags.SPIDER_TAG) || target.CompareTag(MyTags.BOSS_TAG))
        {
            anim.Play("BulletExplode");
            canMove = false;
            StartCoroutine(DisableBullet(0.25f));
        }
    }

    private void Move()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
    }

    IEnumerator DisableBullet(float timer)
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
}
