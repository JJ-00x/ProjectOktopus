using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOffitems : MonoBehaviour
{
    [SerializeField] private int moneyWorth;

    [SerializeField] private ScriptableObjectINT money;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PutOff")
        {
            money.value = +moneyWorth;
            Destroy(this);
        }
    }
}
