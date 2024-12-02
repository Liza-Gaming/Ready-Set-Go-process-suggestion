using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

public class StoveSliderBar : SliderBar
{

    public Text textToShow;

    protected override void Start()
    {
        base.Start();
        textToShow.text = "Press the space bar on time!";
    }

    protected override void Update()
    {
        base.Update(); // Use base functionality
        if (isTimerRunning && Input.GetKeyDown(KeyCode.Space))
        {
            HandlePress();
        }
    }

    private void HandlePress()
    {

        if (timerslider.value >= 0.85f && timerslider.value <= 1.6f)
        {
            textToShow.text = "On time!";
            stopTimer = true;
            SceneManager.LoadScene(0); // Load main scene if space is pressed at the right time
        }
        if (timerslider.value < 0.85f)
        {
            textToShow.text = "To late";
            stopTimer = true;
            StartCoroutine(ShowFeedbackAndReset());
        }
        if (timerslider.value > 1.6f)
        {
            textToShow.text = "To early";
            stopTimer = true;
            StartCoroutine(ShowFeedbackAndReset());
        }
        else
        {
            stopTimer = true;
            StartCoroutine(ShowFeedbackAndReset());
        }
    }

    private System.Collections.IEnumerator ShowFeedbackAndReset()
    {
        // Display feedback here if needed
        yield return new WaitForSeconds(2);
        textToShow.text = "Press the space bar on time!";
        ResetTimer();
    }
}