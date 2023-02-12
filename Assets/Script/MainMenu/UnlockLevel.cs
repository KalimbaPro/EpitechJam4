using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevel : MonoBehaviour
{
    public bool unlocked = false;
    public GameObject levelButton;
    public GameObject levelImage;


    void Update()
    {
        if (unlocked)
        {
            levelButton.SetActive(true);
            levelImage.SetActive(false);
        } else
        {
            levelButton.SetActive(false);
            levelImage.SetActive(true);
        }
    }

    public void Unlock()
    {
        unlocked = true;
    }
}
