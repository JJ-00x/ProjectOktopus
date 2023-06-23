using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Transform hands;
    [SerializeField] private GameObject itemToPickUp;

    private bool hasItem;

    private void Start()
    {
        hasItem = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !hasItem)
        {
            hasItem = true;
            itemToPickUp.transform.position = hands.transform.position;
            itemToPickUp.transform.SetParent(hands, true);
        }
        else if (Input.GetKeyDown(KeyCode.E) && hasItem)
        {
            hasItem = false;
            itemToPickUp.transform.SetParent(null, true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp" && !hasItem)
        {
            itemToPickUp = other.gameObject;
        }
    }
}
