using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject stone;
    public Transform attackPos;

    private string coroutineName = "StartAttack";

    private Animator anim;

    private void Awake()
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

    IEnumerator StartAttack()
    {
        yield return new WaitForSeconds(Random.Range(2f, 5f));

        anim.Play("BossAttack");

        StartCoroutine(coroutineName);
    }

    public void BackToIdle()
    {
        anim.Play("BossIdle");
    }

    public void Attack()
    {
        GameObject obj = Instantiate(stone, attackPos.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-700f, -300f), 0f));
    }

    public void DeactivateBossScript()
    {
        StopCoroutine(coroutineName);
        enabled = false;
    }
}
