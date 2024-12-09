using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine; 

// The StoveSliderBar class inherits from the SliderBar class
public class StoveSliderBar : SliderBar
{
    [SerializeField]
    [Tooltip("Reference to a UI Text element to display messages")]
    public Text textToShow;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start(); // Call the base class's Start method
        textToShow.text = "Press the space bar on time!"; // Initial instruction message
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update(); // Use base class update functionality

        // Check if the timer is running and if the space bar is pressed
        if (isTimerRunning && Input.GetKeyDown(KeyCode.Space))
        {
            HandlePress(); // Handle the space bar press
        }

        // Check if the timer has run out
        if (timerslider.value <= 0)
        {
            textToShow.text = "Too late"; // Display late message
            stopTimer = true; // Stop the timer
            StartCoroutine(ShowFeedbackAndReset()); // Show feedback and reset the timer
        }
    }

    // Method to handle the space bar press event
    private void HandlePress()
    {
        // Check if the space bar was pressed within the "on time" range
        if (timerslider.value >= 0.85f && timerslider.value <= 1.6f)
        {
            textToShow.text = "On time!"; // Display success message
            stopTimer = true; // Stop the timer
            SceneManager.LoadScene(0); // Reload the scene
        }
        // Check if the space bar was pressed too late
        else if (timerslider.value < 0.85f)
        {
            textToShow.text = "Too late"; // Display late message
            stopTimer = true;
            StartCoroutine(ShowFeedbackAndReset());
        }
        // Check if the space bar was pressed too early
        else if (timerslider.value > 1.6f)
        {
            textToShow.text = "Too early"; // Display early message
            stopTimer = true;
            StartCoroutine(ShowFeedbackAndReset());
        }
        // Any other case, ensuring reset happens
        else
        {
            stopTimer = true;
            StartCoroutine(ShowFeedbackAndReset());
        }
    }

    // Coroutine to show feedback and reset the timer
    private System.Collections.IEnumerator ShowFeedbackAndReset()
    {
        yield return new WaitForSeconds(2); // Wait for 2 seconds for the feedback to be visible
        textToShow.text = "Press the space bar on time!"; // Reset instruction message
        ResetTimer(); 
    }
}