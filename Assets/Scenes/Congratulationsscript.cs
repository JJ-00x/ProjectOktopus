using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Congratulationsscript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI money;

    [SerializeField] private ScriptableObjectINT playerMoney;
    // Start is called before the first frame update
    void Start()
    {
        money.text = playerMoney.value.ToString() + "$";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        playerMoney.value = 0;
        SceneManager.LoadScene(1);
    }
}
