using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class CountDown : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public TextMeshProUGUI canvastext;
    public GameObject canvas; 
    public ScriptableObjectINT moneyOnScene;
    public ScriptableObjectINT allPlayerMoney;
    public TextMeshProUGUI moneytext;
    private int moneytextint;
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
                moneytextint = (int)timeRemaining;
                canvastext.text = moneytextint.ToString() + "s";
            }
            else
            {
                allPlayerMoney.value += moneyOnScene.value;
                canvas.SetActive(true);
                timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene(11);
            }
        }

        
        moneytext.text = moneyOnScene.value.ToString() + "$";
        
    }

    private void OnDestroy()
    {
        
    }
}
