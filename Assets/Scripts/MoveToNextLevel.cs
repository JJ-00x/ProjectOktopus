using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevel : MonoBehaviour
{
    public int nextSceneLoad;

    private void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nextSceneLoad);

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }
}
