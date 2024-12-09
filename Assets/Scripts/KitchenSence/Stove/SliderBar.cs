using UnityEngine;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    [SerializeField]
    [Tooltip("A UI Slider used to visually represent the countdown time")]
    public Slider timerslider;

    [SerializeField]
    [Tooltip("Flag to indicate whether the timer should stop")]
    protected bool stopTimer;

    // Flag to indicate if the timer is running
    protected bool isTimerRunning;

    [SerializeField]
    [Tooltip("The maximum time the slider will represent (initial timer value")]
    public float maxTime;

    // The Start method is called before the first frame update
    protected virtual void Start()
    {
        ResetTimer(); // Initialize and reset timer
        StartCountdown(); // Begin countdown immediately
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        // If the timer is not supposed to be running, exit Update early
        if (!isTimerRunning)
            return;

        // Calculate the remaining time
        float time = timerslider.value - Time.deltaTime;

        // If the time has elapsed, stop the timer and reset it
        if (time <= 0)
        {
            stopTimer = true; 
            isTimerRunning = false; 
            ResetTimer(); // Reset timer to initial state
        }

        // If the timer should not be stopped, update the slider value
        if (!stopTimer)
        {
            timerslider.value = time; // Set new slider value based on time
        }
    }

    // Method to start the countdown by marking the timer as running
    protected void StartCountdown()
    {
        isTimerRunning = true;
    }

    // Method to reset the timer to its starting state
    protected virtual void ResetTimer()
    {
        stopTimer = false; 
        timerslider.value = maxTime; 
        StartCountdown(); // Restart the countdown
    }
}