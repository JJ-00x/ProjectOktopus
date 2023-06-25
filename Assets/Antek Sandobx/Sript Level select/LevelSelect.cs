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
    [SerializeField] private ScriptableObjectINT playerMoney;
    [SerializeField] private int sceneRange1max;
    [SerializeField] private int sceneRange1min;
    [SerializeField] private int sceneRange2max;
    [SerializeField] private int sceneRange2min;

    [SerializeField] private TextMeshProUGUI textPriceOfScene1;
    [SerializeField] private TextMeshProUGUI textPriceOfScene2;

    [SerializeField] private TextMeshProUGUI youLose;
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
        ImageChoosing(0);
        ImageChoosing(1);
        price_level_1 = Random.Range(minCost, maxCost);
        price_level_2 = Random.Range(minCost, maxCost);
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
            SceneManager.LoadScene(sceneChoosed[0]);
        }
    }
    public void ChooseScene2()
    {
        if (playerMoney.value > price_level_2)
        {
            playerMoney.value -= price_level_2;
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
                    roomName[index].text = "Livingroom";
                    sceneChoosed[index] = Random.Range(sceneRangeLivingroom[0], sceneRangeLivingroom.Count);
                    break;
                case 2:
                    _images[index].sprite = sprites[1];
                    roomName[index].text = "Bathroom";
                    sceneChoosed[index] = Random.Range(sceneRangeBathroom[0], sceneRangeBathroom.Count);
                    break;
                case 3:
                    _images[index].sprite = sprites[2];
                    roomName[index].text = "Kidsroom";
                    sceneChoosed[index] = Random.Range(sceneRangeKidsRoom[0], sceneRangeKidsRoom.Count);
                    break;
                default:
                    break;
            }
    }
}
