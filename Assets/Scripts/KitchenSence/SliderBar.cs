using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    public Slider timerslider;
    protected bool stopTimer;
    protected bool isTimerRunning;
    public float maxTime;

    // Start is called before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        ResetTimer();
        StartCountdown();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (!isTimerRunning)
            return;

        float time = timerslider.value - Time.deltaTime;

        if (time <= 0)
        {
            stopTimer = true;
            isTimerRunning = false;
            ResetTimer(); // Reset the timer when it runs out
        }

        if (!stopTimer)
        {
            timerslider.value = time;
        }
    }

    protected void StartCountdown()
    {
        isTimerRunning = true;
    }

    protected virtual void ResetTimer()
    {
        stopTimer = false;
        timerslider.value = maxTime;
        StartCountdown();
    }
}