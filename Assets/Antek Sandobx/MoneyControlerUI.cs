using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyControlerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI money;

    [SerializeField] private ScriptableObjectINT moneySO;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        money.text = moneySO.value.ToString();
    }
}
