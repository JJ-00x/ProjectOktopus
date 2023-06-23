using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject hands;
    private GameObject itemToPickUp;

    private bool hasItem;
    private bool canTakeItem;

    private void Start()
    {
        hasItem = false;
        canTakeItem = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasItem && canTakeItem)
        {
            hasItem = true;
            canTakeItem = false;
            
            itemToPickUp.transform.position = hands.transform.position;
            itemToPickUp.transform.parent = hands.transform;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PickUp" && !hasItem)
        {
            itemToPickUp = other.gameObject;
            hasItem = true;
        }
    }
}
