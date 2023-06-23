using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float countdownTime = 60f; // Set the initial countdown time in seconds
    public TMP_Text countdownText; // Reference to the TMP text element

    private float currentTime; // Current time remaining

    private void Start()
    {
        currentTime = countdownTime;
    }

    private void Update()
    {
        // Update the timer and display it
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        // Check if the timer has reached zero
        if (currentTime <= 0f)
        {
            // Timer has expired, perform desired action
            TimerExpired();
        }
    }

    private void TimerExpired()
    {
        // Perform the desired action when the timer expires
        countdownText.text = "Time's Up!";
        // Add any other actions or logic here
        //Game Over / Pause / Exit to menu
    }
}