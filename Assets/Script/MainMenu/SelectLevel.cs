using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public string levelOne;
    public string levelTwo;
    public string levelThree;

    public GameObject levelCanvas;
    public GameObject mainMenuCanvas;

    private IEnumerator startDelay(string levelToLoad)
    {

        yield return new WaitForSeconds(0.40f);
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadLevelOne()
    {
        StartCoroutine(startDelay(levelOne));
    }
    public void LoadLevelTwo()
    {
        StartCoroutine(startDelay(levelTwo));
    }
    public void LoadLevelThree()
    {
        StartCoroutine(startDelay(levelThree));
    }

    private IEnumerator goBackMenuDelay()
    {

        yield return new WaitForSeconds(0.40f);
        mainMenuCanvas.SetActive(true);
        levelCanvas.SetActive(false);
    }

    public void GoBackMenu()
    {
        StartCoroutine(goBackMenuDelay());
    }
}
