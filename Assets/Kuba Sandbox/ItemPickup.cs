using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Transform hands;
    
    public static GameObject itemToPickUp;

    private bool hasItem;
    
    public float throwStrenght = 0f;
    public float timeToThrow = 1;
    
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
            
            Destroy(itemToPickUp.GetComponent<Rigidbody>());
        }
        else if (Input.GetKeyDown(KeyCode.E) && hasItem)
        {
            hasItem = false;
            AddRigidbody();
            
            itemToPickUp.transform.SetParent(null, true);
        }
        
        if (Input.GetKey(KeyCode.R) && hasItem)
        {
            Debug.Log(throwStrenght);
            throwStrenght += (timeToThrow + 1) * Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.R) && hasItem)
        {
            hasItem = false;
            AddRigidbody();
            
            itemToPickUp.GetComponent<Rigidbody>().AddForce(transform.forward * throwStrenght, ForceMode.Impulse);
            itemToPickUp.transform.SetParent(null, true);
            throwStrenght = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp" && !hasItem)
        {
            Debug.Log("ITEM");
            itemToPickUp = other.gameObject;
        }
    }

    private void AddRigidbody()
    {
        itemToPickUp.AddComponent<Rigidbody>();
        itemToPickUp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
