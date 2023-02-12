using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class stats : MonoBehaviour
{
    public float time;
    public int pp = 100;
    public int fscore = 0;
    public int ekilled = 0;
    public int level;
    [SerializeField] TextMeshProUGUI scoreText;

    // Update is called once per frame
    
    private IEnumerator updateDelay()
    {
        yield return new WaitForSeconds(1.5f);
        score();
        pp = 100;
        SceneManager.LoadScene("MainMenu");
    }

    public void Update()
    {
        
        if (ekilled == 5)
        {
            SceneManager.LoadScene("Level " + (level + 1).ToString());
            pp = 100;
        }
        else if (ekilled == 1 && level == 3)
        {
            StartCoroutine(updateDelay());
        }
        if (pp == 0)
        {
            scoreText.text = "GAME OVER";
        }

    }

    public void addTime(int d)
    {
        time += d * Time.deltaTime;
    }
    public void removePP(int d)
    {
        pp -= d;
    }
    public void score()
    {
        fscore = (int) (1 / time * 1000);
    }
}
