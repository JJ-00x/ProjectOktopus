using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class LevelSelect : MonoBehaviour
{
    private int price_level_1;
    private int price_level_2;
    private int scene1;
    private int scene2;

    [SerializeField] private int maxCost;  
    [SerializeField] private int minCost;
    [SerializeField] private ScriptableObjectINT playerMoney;
    [SerializeField] private int sceneRange1max;
    [SerializeField] private int sceneRange1min;
    [SerializeField] private int sceneRange2max;
    [SerializeField] private int sceneRange2min;

    [SerializeField] private TextMeshProUGUI textPriceOfScene1;
    [SerializeField] private TextMeshProUGUI textPriceOfScene2;

    [SerializeField] private TextMeshProUGUI youLose;
    
    
    
    
    // Start is called before the first frame update
    void Awake()
    {
      price_level_1 = Random.Range(minCost, maxCost);
      price_level_2 = Random.Range(minCost, maxCost);
      scene1 = Random.Range(sceneRange1min, sceneRange1max);
      scene2 = Random.Range(sceneRange2min, sceneRange2max);
    }

    private void Start()
    {
        if (playerMoney.value > price_level_1 && playerMoney.value > price_level_2)
        {
            textPriceOfScene1.text = price_level_1.ToString();
            textPriceOfScene2.text = price_level_2.ToString();
        }
        else
        {
            youLose.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void ChooseScene1()
    {
        if(playerMoney.value > price_level_1)
        {
            playerMoney.value -= price_level_1;
            SceneManager.LoadScene(scene1);
        }
    }
    public void ChooseScene2()
    {
        if (playerMoney.value > price_level_2)
        {
            playerMoney.value -= price_level_2;
            SceneManager.LoadScene(scene2);
        }
        
        
    }
}
