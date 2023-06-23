using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{

    public Button[] levelButtons;

    private void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
                levelButtons[i].interactable = false;
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
    
    public void LoadLevel1()
    {
        //SceneManager.LoadScene(""); 
        //LevelName
    }
    public void LoadLevel2()
    {
        //SceneManager.LoadScene("");
        //LevelName
    }
    public void LoadLevel3()
    {
        //SceneManager.LoadScene("");
        //LevelName
    }

}
