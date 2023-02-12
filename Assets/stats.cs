using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class stats : MonoBehaviour
{
    public float time;
    public int fscore = 0;
    public int health = 30;
    public int level;
    [SerializeField] TextMeshProUGUI scoreText;

    // Update is called once per frame
    
    private IEnumerator updateDelay()
    {
        yield return new WaitForSeconds(1.5f);
        score();
        SceneManager.LoadScene("MainMenu");
    }

    public void Update()
    {
        GameObject[] fires = GameObject.FindGameObjectsWithTag("fire");
        if (fires.Length == 0)
        {
            SceneManager.LoadScene("Level " + (level + 1).ToString());
        }
        else if (fires.Length == 0 && level == 3)
        {
            StartCoroutine(updateDelay());
        }
        if (health <= 0)
        {
            scoreText.text = "GAME OVER";
        }

    }

    public void addTime(int d)
    {
        time += d * Time.deltaTime;
    }
    public void score()
    {
        fscore = (int) (1 / time * 1000);
    }
    public void TakeDamage(int d)
    {
        health -= d;
        if (health <= 0)
        {
            // Die();
        }
    }
}
