using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WindowsClockBehviour : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;

    void Update()
    {
        timerText.text = System.DateTime.Now.ToShortTimeString();
    }
}
