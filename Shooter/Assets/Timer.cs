using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Text;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text TMPtext; 

    private float time;
    private bool isActive;

    private void Start()
    {
        if (TMPtext == null) TMPtext = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        if (isActive)
        {
            time += Time.deltaTime;
        }

        FormatAndDisplayTime();
    }

    private void FormatAndDisplayTime()
    {
        int min = Mathf.FloorToInt(time / 60);
        int sec = Mathf.FloorToInt(time % 60);
        int ms = (int)((time * 1000) % 1000);

        TMPtext.text = min.ToString("00") + ":" + sec.ToString("00") + ":" + ms.ToString("0000");
    }

    public void StartTimer() => isActive = true;
    public void StopTimer() => isActive = false;
}
