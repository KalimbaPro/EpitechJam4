using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ppremain : MonoBehaviour
{
    public stats carapuce;
    [SerializeField] TextMeshProUGUI ppText;

    void Update()
    {
        ppText.text = "PP remaining:   " + carapuce.pp.ToString() + "/100";
    }
}
