using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public Transform hands;
    public static GameObject itemToPickUp;

    public static bool hasItem;
    
    public float throwStrenght = 0f;
    public float maxthrowStrenght = 15f;
    public float timeToThrow = 7;

    public GameObject throwStrSliderGameObject;
    public Slider throwStrSlider;
    public Gradient throwColor;
    public Image fill;
    [SerializeField] private ScriptableObjectBOOL hasItemSO;
    [SerializeField] private ScriptableObjectINT speed;
    
     void Start()
     {
         hasItem = false;
        hasItemSO.value = false;
        throwStrSliderGameObject.SetActive(false);
    }

     void Update()
    {
        //object interaction
        switch (speed.value)
        {
            case 5:
                maxthrowStrenght = 15f;
                break;
            case 4:
                maxthrowStrenght = 10f;
                break;
            case 3:
                maxthrowStrenght = 5f;
                break;
            default:
                break;
        }
        
        PickUpDropItem();
        ThrowItem();
        
        //slider
        ThrowSlider();
        SetMaxThrowStrenght();
       
    }
    
    private void ThrowItem()
    {
        if (Input.GetKey(KeyCode.R) && hasItemSO.value)
        {
            throwStrenght += (timeToThrow + 1) * Time.deltaTime;

            throwStrSliderGameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.R) && hasItemSO.value)
        {
            hasItemSO.value = false;
            hasItem = false;
            AddRigidbody();

            itemToPickUp.GetComponent<Rigidbody>().AddForce(transform.forward * throwStrenght, ForceMode.Impulse);
            itemToPickUp.transform.SetParent(null, true);
            throwStrenght = 0;

            throwStrSliderGameObject.SetActive(false);
        }
    }

    private void PickUpDropItem()
    {
        if (itemToPickUp == null)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && !hasItemSO.value)
        {  
            hasItemSO.value = true;
            hasItem = true;

            itemToPickUp.transform.SetParent(hands, true);
            itemToPickUp.transform.position = hands.transform.position;

            itemToPickUp.transform.rotation = Quaternion.identity;

            Destroy(itemToPickUp.GetComponent<Rigidbody>());
        }
        else if (Input.GetKeyDown(KeyCode.E) && hasItemSO.value)
        {
            hasItemSO.value = false;
            hasItem = false;
            AddRigidbody();

            itemToPickUp.transform.SetParent(null, true);
        }
    }

    private void ThrowSlider()
    {
        throwStrSlider.maxValue = maxthrowStrenght;
        throwStrSlider.value = throwStrenght;

        fill.color = throwColor.Evaluate(throwStrSlider.normalizedValue);
    }
    
    private void SetMaxThrowStrenght()
    {
        if (throwStrenght >= maxthrowStrenght)
        {
            throwStrenght = maxthrowStrenght;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp" && !hasItemSO.value)
        {
            Debug.Log("ITEM");
            itemToPickUp = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickUp" && !hasItemSO.value)
        {
            Debug.Log("ITEM");
            itemToPickUp = null;
        }
    }

    private void AddRigidbody()
    {
        itemToPickUp.AddComponent<Rigidbody>();
        itemToPickUp.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
}
