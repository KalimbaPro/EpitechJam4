using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelToLoad;

    public GameObject buttons;
    public GameObject settingsWindow;

    public GameObject levelCanvas;
    public GameObject mainMenuCanvas;

    public Image title;
    public Image subTitle;

    private IEnumerator startDelay()
    {
        yield return new WaitForSeconds(0.40f);
        mainMenuCanvas.SetActive(false);
        levelCanvas.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(startDelay());
    }

    private IEnumerator settingDelay()
    {

        yield return new WaitForSeconds(0.40f);
        Cursor.visible = true;
        settingsWindow.SetActive(true);
        title.enabled = false;
        subTitle.enabled = false;
        buttons.SetActive(false);
    }

    public void SettingButton()
    {

        StartCoroutine(settingDelay());
    }

    private IEnumerator closeSettingDelay()
    {
        yield return new WaitForSeconds(0.40f);
        settingsWindow.SetActive(false);
        Cursor.visible = true;
        title.enabled = true;
        subTitle.enabled = true;
        buttons.SetActive(true);
    }

    public void CloseSettingsWindow()
    {
        StartCoroutine(closeSettingDelay());
    }
    private IEnumerator quitDelay()
    {

        yield return new WaitForSeconds(0.40f);
        Application.Quit();
    }

    public void QuitGame()
    {
        StartCoroutine(quitDelay());
    }
}
