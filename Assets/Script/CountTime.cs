using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountTime : MonoBehaviour
{
    public stats carapuce;
    [SerializeField] TextMeshProUGUI CountdownText;

    void Update()
    {
        carapuce.addTime(1);
        CountdownText.text = "Time:   " + carapuce.time.ToString("0") + "s";
    }
}
