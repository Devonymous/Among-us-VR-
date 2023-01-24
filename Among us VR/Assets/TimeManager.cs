using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float timer;
    bool Running = true;

    // Update is called once per frame
    void Update()
    {
        CountTime();

    }

    void CountTime()
    {
        if (Running)
        {
            timer += Time.deltaTime;
        }
    }

    void logTime()
    {
        Debug.Log((timer / 3600).ToString("00") + ":" + (timer / 60).ToString("00") + ":" + (timer % 60).ToString("00"));
    }

    public void SetTimerRunning(bool running)
    {
        Running = running;
    }
}
