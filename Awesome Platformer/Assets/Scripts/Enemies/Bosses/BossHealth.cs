using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    private int health = 10;
    private bool canDamage;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        canDamage = true;
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (canDamage)
        {
            if (target.CompareTag(MyTags.BULLET_TAG))
            {
                health--;
                canDamage = false;

                if (health <= 0)
                {
                    GetComponent<Boss>().DeactivateBossScript();
                    anim.Play("BossDie");
                }

                StartCoroutine(WaitForDamage());
            }
        }
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }
}
