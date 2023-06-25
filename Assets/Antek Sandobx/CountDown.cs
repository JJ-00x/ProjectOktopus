using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public GameObject canvas;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                canvas.SetActive(true);
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }
}
