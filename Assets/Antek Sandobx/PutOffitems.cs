using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class PutOffitems : MonoBehaviour
{
    [SerializeField] private int moneyWorth;
    [SerializeField] private int maxValue;
    [SerializeField] private int minValue;

    [SerializeField] private ScriptableObjectINT money;
    
    // Start is called before the first frame update
    void Start()
    {
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
            money.value += moneyWorth;
            Destroy(gameObject);
        }
    }
}
