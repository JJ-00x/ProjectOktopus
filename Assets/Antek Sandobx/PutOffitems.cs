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
    [SerializeField] private ScriptableObjectBOOL hasItemSO;
    [SerializeField] private ScriptableObjectBOOL isPopUpEnable;
    [SerializeField] private ScriptableObjectINT objectPrice;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        isPopUpEnable.value = false;
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
            objectPrice.value = moneyWorth;
            isPopUpEnable.value = true;
            money.value += moneyWorth;
            hasItemSO.value = false;
            Destroy(gameObject);
        }
    }
}
