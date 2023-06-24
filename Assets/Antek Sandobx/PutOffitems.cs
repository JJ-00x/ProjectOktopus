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

    [SerializeField] private ScriptableObjectINT weightspeed;

    [SerializeField] private ScriptableObjectINT speed;

    [SerializeField] private ScriptableObjectBOOL hasItem;
    // Start is called before the first frame update
    void Start()
    {
        moneyWorth = UnityEngine.Random.Range(minValue, maxValue);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasItem.value = true)
        {
            speed.value = weightspeed.value;
        }
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
