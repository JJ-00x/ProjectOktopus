using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyOverAll : MonoBehaviour
{
    [SerializeField] private ScriptableObjectINT moneyOnScene;

    [SerializeField] private ScriptableObjectINT overAllMoney;

    [SerializeField] private TextMeshProUGUI textMoney;
    // Start is called before the first frame update
    void Start()
    {
        textMoney.text = moneyOnScene.value.ToString() + "$";
    }

    // Update is called once per frame
   

    private void OnDestroy()
    {
        overAllMoney.value += moneyOnScene.value;
    }

    
}
