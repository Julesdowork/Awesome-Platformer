using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Deactivate", 4f);
    }

    void Deactivate()
    {
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag(MyTags.PLAYER_TAG))
        {
            target.GetComponent<PlayerHealth>().DealDamage();
            gameObject.SetActive(false);
        }
    }
}
