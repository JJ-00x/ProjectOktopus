using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumWeightitem : MonoBehaviour
{
    [SerializeField] private ScriptableObjectBOOL hasItem;

    [SerializeField] private ScriptableObjectINT moveSpeed;

    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasItem.value && Vector3.Distance(transform.position, target.transform.position) < 2f)
        {
            moveSpeed.value = 4;
            Debug.Log(moveSpeed.value);
        }
    }
}
