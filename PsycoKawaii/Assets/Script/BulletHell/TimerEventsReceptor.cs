using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEventsReceptor : MonoBehaviour
{
    private void Start()
    {
        Goodness.notifyDestroyed += StopTimer;
        Evilness.notifyGameOver += StopTimer;
    }

    private void StopTimer()
    {
        GetComponent<Timer>().IsRunning = false;
    }
}
