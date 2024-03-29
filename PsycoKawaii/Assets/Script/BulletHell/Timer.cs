﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public delegate void TimerDelegate();
    public static event TimerDelegate notifyTimeRanOut;
    [SerializeField] private float _currentTime;
    public bool IsRunning { get; set; }
    private TextMeshProUGUI _timeText;
    private AudioSource _audioSource; 

    private void Start()
    {
        _timeText = GetComponent<TextMeshProUGUI>();
        GameActivator.startGame += StartRunning;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        GameActivator.startGame -= StartRunning;
    }

    private void StartRunning()
    {
        IsRunning = true;
        StartCoroutine(Beep());
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRunning)
        {
            DisplayTime(_currentTime);
            _currentTime -= Time.deltaTime;
        }
            
        if (_currentTime <= 0 && IsRunning)
        {
            IsRunning   = false;
            notifyTimeRanOut?.Invoke();
        }   
    }

    private IEnumerator Beep()
    {
        if(IsRunning)
        for (int i = 0; i < 9; i++)
        {
            _audioSource.Play();
            yield return new WaitForSeconds(1);
        }
    }
}
