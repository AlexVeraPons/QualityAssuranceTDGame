/*
    Timer class represents a countdown timer in a game.
    It allows starting, stopping, and resetting the timer.
    The timer can invoke events when it starts, stops, and reaches the maximum time.

    Example usage:
    !!! Make sure to call the Update() method in the Update() method of the MonoBehaviour that uses the timer !!!
    Timer timer = new Timer(60f); // Create a timer with a maximum time of 60 seconds
    timer.OnTimerStart += () => Debug.Log("Timer started"); // Subscribe to the OnTimerStart event
    timer.OnTimerEnd += () => Debug.Log("Timer ended"); // Subscribe to the OnTimerEnd event
    timer.Start(); // Start the timer\

    Made by: Alexandro Vera
*/

using System;
using UnityEngine;

/// <summary>
/// Represents a timer utility class that can be used to measure time intervals.
/// </summary>
public class Timer
{
    // Events
    public Action OnTimerEnd;
    public Action OnTimerStart;
    public Action OnStopTimer;
    public Action TimerReset;

    // Properties
    private bool _startTimerOnStart = false;
    public bool StartTimerOnStart
    {
        get { return _startTimerOnStart; }
        set { _startTimerOnStart = value; }
    }

    private bool _automaticReset = false;
    public bool AutomaticReset
    {
        get { return _automaticReset; }
        set { _automaticReset = value; }
    }

    // Fields
    private bool _timerRunning = false;
    private float _time;

    [SerializeField] private float _maxTime;

    public Timer() { }

    public Timer(float maxTime)
    {
        _maxTime = maxTime;
        if (_startTimerOnStart)
        {
            StartTimer();
        }
    }

    public Timer(float maxTime, bool automaticReset = false, bool startTimerOnStart = false)
    {
        _maxTime = maxTime;
        this._automaticReset = automaticReset;
        if (startTimerOnStart)
        {
            StartTimer();
        }
    }

    public void SetMaxTime(float maxTime)
    {
        _maxTime = maxTime;
    }

    public void StartTimer()
    {
        if (_timerRunning)
        {
            return;
        }

        _timerRunning = true;
        OnTimerStart?.Invoke();
    }

    public void StopTimer()
    {
        if (!_timerRunning)
        {
            return;
        }

        _timerRunning = false;
        OnStopTimer?.Invoke();
    }

    public void RestartTimer()
    {
        _time = 0;
        StartTimer();
    }


    public void UpdateTimer()
    {
        if (_timerRunning)
        {
            RunTimer();
        }
    }

    private void RunTimer()
    {
        _time += Time.deltaTime;
        if (_time >= _maxTime)
        {
            OnTimerEnd?.Invoke();

            if (_automaticReset)
            {
                RestartTimer();
            }
            else
            {
                StopTimer();
            }
        }
    }

    internal float GetTime()
    {
        return _time;
    }
}