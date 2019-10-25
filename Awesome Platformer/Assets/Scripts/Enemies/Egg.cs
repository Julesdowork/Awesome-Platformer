using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.CompareTag(MyTags.PLAYER_TAG))
        {
            target.gameObject.GetComponent<PlayerHealth>().DealDamage();
        }
        gameObject.SetActive(false);
    }
}
