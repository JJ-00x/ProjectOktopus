using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class PutOffitems : MonoBehaviour
{
    [SerializeField] private int moneyWorth;
    [SerializeField] private int maxValue;
    [SerializeField] private int minValue;

    [SerializeField] private ScriptableObjectINT money;
    [SerializeField] private TextMeshProUGUI popUp;
    [SerializeField] private ScriptableObjectBOOL hasItemSO;
    
    
    // Start is called before the first frame update
    void Start()
    {
        popUp.enabled = false;
        moneyWorth = UnityEngine.Random.Range(minValue, maxValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PutOff")
        {
            popUp.text ="+" + moneyWorth.ToString();
            popUp.enabled = true;
            money.value += moneyWorth;
            hasItemSO.value = false;
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Invoke("TrunOffText", 2f);
    }

    void TrunOffText()
    {
        popUp.enabled = false;
    }
}
