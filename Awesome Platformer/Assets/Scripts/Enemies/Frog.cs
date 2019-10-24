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

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(Random.Range(1f, 4f));

        if (jumpLeft)
        {
            anim.Play("FrogJumpLeft");
        }
        else
        {

        }

        StartCoroutine(coroutineName);
    }

    public void AnimationFinished()
    {
        anim.Play("FrogIdleLeft");
    }
}
