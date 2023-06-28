using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelSelect : MonoBehaviour
{
    private int numberOfScenes;
    private int price_level_1;
    private int price_level_2;
    private int scene1;
    private int scene2;

    [SerializeField] private int maxCost;  
    [SerializeField] private int minCost;
    [SerializeField] private ScriptableObjectINT allPlayerMoney;
    [SerializeField] private TextMeshProUGUI textPlayerMoney;
    [SerializeField] private ScriptableObjectINT levelPriceMultiplication;
    
    [SerializeField] private TextMeshProUGUI textPriceOfScene1;
    [SerializeField] private TextMeshProUGUI textPriceOfScene2;

    [SerializeField] private GameObject youLose;
    [SerializeField] private GameObject nextLevel;
    [SerializeField] private Sprite[] sprites;

    [SerializeField] private List<Image> _images = new List<Image>();
    [SerializeField] private List<TextMeshProUGUI> roomName = new List<TextMeshProUGUI>();
    [SerializeField] private List<int> sceneRangeLivingroom = new List<int>();
    [SerializeField] private List<int> sceneRangeBathroom = new List<int>();
    [SerializeField] private List<int> sceneRangeKidsRoom = new List<int>();
    [SerializeField] private List<int> sceneChoosed = new List<int>();

   
    

    
    // Start is called before the first frame update
    void Awake()
    {   
        youLose.SetActive(false);
        ImageChoosing(0);
        ImageChoosing(1);
        price_level_1 = Random.Range(minCost, maxCost);
        price_level_2 = Random.Range(minCost, maxCost);
        price_level_1 = (int)(levelPriceMultiplication.value * price_level_1);
        price_level_2 = (int)(price_level_1 * levelPriceMultiplication.value);
        levelPriceMultiplication.value += 0.5f;
    }

    private void Start()
    {
        if (allPlayerMoney.value > price_level_1 && allPlayerMoney.value > price_level_2)
        {
            textPriceOfScene1.text = price_level_1.ToString();
            textPriceOfScene2.text = price_level_2.ToString();
        }
        else
        {
            youLose.SetActive(true);
            nextLevel.SetActive(false);
        }
        textPlayerMoney.text = "Your Money: " + allPlayerMoney.value.ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
       
    }

    public void ChooseScene1()
    {
        if(allPlayerMoney.value > price_level_1)
        {
            allPlayerMoney.value -= price_level_1;
            SceneManager.LoadScene(sceneChoosed[0]);
        }
    }
    public void ChooseScene2()
    {
        if (allPlayerMoney.value > price_level_2)
        {
            allPlayerMoney.value -= price_level_2;
            SceneManager.LoadScene(sceneChoosed[1]);
        }
    }

    private void ImageChoosing(int index)
    {
        numberOfScenes = Random.Range(1, 4);

            switch (numberOfScenes)
            {
                case 1:
                    _images[index].sprite = sprites[0];
                    roomName[index].text = "Living Room";
                    sceneChoosed[index] = Random.Range(sceneRangeLivingroom[0], sceneRangeLivingroom.Count);
                    break;
                case 2:
                    _images[index].sprite = sprites[1];
                    roomName[index].text = "Bathroom";
                    sceneChoosed[index] = Random.Range(sceneRangeBathroom[0], sceneRangeBathroom.Count);
                    break;
                case 3:
                    _images[index].sprite = sprites[2];
                    roomName[index].text = "Kid's room";
                    sceneChoosed[index] = Random.Range(sceneRangeKidsRoom[0], sceneRangeKidsRoom.Count);
                    break;
                default:
                    break;
            }
    }
    public void RestartButton()
    {
        allPlayerMoney.value = 500;
        SceneManager.LoadScene(0);
    }
}
