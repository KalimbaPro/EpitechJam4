using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class KonamiCode : MonoBehaviour
{
    [SerializeField] public string buffer;
    [SerializeField] private UnityEvent unlockAllLevels;
    public AudioSource konamiSound;

    [SerializeField] private float maxTimeDif = 1;
    private string validPattern = "UUDDLRLRBL";
    private float timeDif;

    // Start is called before the first frame update
    void Start()
    {
        timeDif = maxTimeDif;
    }

    // Update is called once per frame
    void Update()
    {
        timeDif -= Time.deltaTime;
        if (timeDif <= 0)
        {
            buffer = "";
        }
        if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") > 0)
        {
            addToBuffer("U");
        }
        else if (Input.GetButtonDown("Vertical") && Input.GetAxisRaw("Vertical") < 0)
        {
            addToBuffer("D");
        }
        else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") > 0)
        {
            addToBuffer("R");
        }
        else if (Input.GetButtonDown("Horizontal") && Input.GetAxisRaw("Horizontal") < 0)
        {
            addToBuffer("L");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            addToBuffer("B");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            addToBuffer("L");
        }
        checkPatterns();
    }

    void addToBuffer(string str)
    {
        timeDif = maxTimeDif;
        buffer += str;
    }

    void checkPatterns()
    {
        if(buffer.EndsWith(validPattern))
        {
            Debug.Log("Konami Code");
            buffer = "";
            konamiSound.Play();
            unlockAllLevels.Invoke();
        }
    }
}
