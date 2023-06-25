using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public TextMeshProUGUI canvastext;
    public GameObject canvas;
    public ScriptableObjectINT money;
    public TextMeshProUGUI moneytext;
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
                canvastext.text = timeRemaining.ToString() + "s";
                
            }
            else
            {
                
                canvas.SetActive(true);
                timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene(11);
            }
        }

        moneytext.text = money.value.ToString() + "$";
    }
}
