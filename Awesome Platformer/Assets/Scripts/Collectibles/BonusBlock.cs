using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : MonoBehaviour
{
    public Transform bottomCollision;
    public LayerMask playerLayer;

    private Vector3 moveDir = Vector3.up;
    private Vector3 originPos;
    private Vector3 animPos;
    private bool startAnim;
    private bool canAnimate = true;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.position;
        animPos = transform.position;
        animPos.y += 0.15f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForCollision();
        AnimateUpDown();
    }

    private void CheckForCollision()
    {
        if (canAnimate)
        {
            RaycastHit2D hit = Physics2D.Raycast(bottomCollision.position, Vector2.down, 0.1f, playerLayer);
            if (hit)
            {
                if (hit.collider.gameObject.CompareTag(MyTags.PLAYER_TAG))
                {
                    // increase score
                    anim.Play("BonusBlockHit");
                    startAnim = true;
                    canAnimate = false;
                }
            }
        }
    }

    private void AnimateUpDown()
    {
        if (startAnim)
        {
            transform.Translate(moveDir * Time.smoothDeltaTime);
            if (transform.position.y >= animPos.y)
                moveDir = Vector3.down;
            else if (transform.position.y <= originPos.y)
                startAnim = false;
        }
    }
}
