using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowWeightItem : MonoBehaviour
{
    [SerializeField] private ScriptableObjectBOOL hasItem;

    [SerializeField] private ScriptableObjectINT moveSpeed;

    [SerializeField] private ScriptableObjectGameObject playerSO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasItem.value && Vector3.Distance(transform.position, playerSO.value.transform.position) < 2f)
        {
            moveSpeed.value = 5;
            Debug.Log(moveSpeed.value);
        }
    }
}
