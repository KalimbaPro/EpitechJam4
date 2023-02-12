using System.Collections;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public GameObject cinematicCanvas;
    public GameObject mainMenuCanvas;

    private IEnumerator startDelay()
    {
        yield return new WaitForSeconds(1.5f);
        mainMenuCanvas.SetActive(true);
        cinematicCanvas.SetActive(false);
    }
    void Start()
    {
        StartCoroutine(startDelay());
    }
}
