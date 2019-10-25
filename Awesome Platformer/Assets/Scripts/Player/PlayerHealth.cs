using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private int lives;
    private bool canDamage;

    private Text livesText;

    void Awake()
    {
        livesText = GameObject.Find("Lives Text").GetComponent<Text>();
        lives = 0;
        livesText.text = "x" + lives;
        canDamage = true;
    }

    void Start()
    {
        Time.timeScale = 1f;
    }

    public void DealDamage()
    {
        if (canDamage)
        {
            lives--;
            if (lives >= 0)
            {
                livesText.text = "x" + lives;
            }
            else
            {
                // Restart the game
                Time.timeScale = 0;
                StartCoroutine(RestartGame());
            }

            canDamage = false;
            StartCoroutine(WaitForDamage());
        }
    }

    IEnumerator WaitForDamage()
    {
        yield return new WaitForSeconds(2f);
        canDamage = true;
    }

    IEnumerator RestartGame()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("Game");
    }
}
