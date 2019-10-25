using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int scoreCount;

    private Text coinText;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        coinText = GameObject.Find("Coins Text").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag(MyTags.COIN_TAG))
        {
            target.gameObject.SetActive(false);
            scoreCount++;
            coinText.text = "x" + scoreCount;
            audioSource.Play();
        }
    }
}
