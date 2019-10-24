using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private bool animationStarted;
    private bool animationFinished;
    private int timesJumped;
    private bool jumpLeft = true;
    private string coroutineName = "Jump";

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coroutineName);
    }

    void LateUpdate()
    {
        if (animationFinished && animationStarted)
        {
            animationStarted = false;
            // Sprite's position is being reset earlier than expected, so I moved this to AnimationFinished()
            //transform.parent.position = transform.position;     // move parent object to sprite's location
            //transform.localPosition = Vector3.zero;             // reset sprite's local position to (0,0,0) (may be redundant due to Idle animation)
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        animationStarted = true;
        animationFinished = false;

        timesJumped++;

        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {
            anim.Play("FrogJumpRight");
        }

        StartCoroutine(coroutineName);
    }

    public void AnimationFinished()
    {
        animationFinished = true;
        transform.parent.position = transform.position;     // move parent object to sprite's location

        if (jumpLeft)
            anim.Play("FrogIdleLeft");
        else
            anim.Play("FrogIdleRight");

        if (timesJumped == 3)
        {
            timesJumped = 0;
            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1;
            transform.localScale = tempScale;

            jumpLeft = !jumpLeft;
        }
    }
}
