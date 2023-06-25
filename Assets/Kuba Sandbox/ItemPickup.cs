using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    public static GameObject itemToPickUp;
    public Transform hands;

    public float throwStrenght = 0f;
    public float maxthrowStrenght = 15f;
    public float timeToThrow = 7;

    public GameObject throwStrSliderGameObject;
    public Slider throwStrSlider;
    public Gradient throwColor;
    public Image fill;

    public  ScriptableObjectBOOL hasItemSO;
    [SerializeField] private ScriptableObjectINT speed;

    public static bool hasItem;


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
            case 20:
                maxthrowStrenght = 40f;
                break;
            case 18:
                maxthrowStrenght = 30f;
                break;
            case 15:
                maxthrowStrenght = 20f;
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



    private void PickUpDropItem()
    {
        if (itemToPickUp == null)
        {
            hasItem = false;
            hasItemSO.value = false;
        }

        /*if (hasItem)
        {
            //itemToPickUp.transform.position = hands.transform.position;
            //itemToPickUp.transform.rotation = hands.rotation;
            itemToPickUp.transform.GetChild(0).transform.position = hands.transform.position;
            itemToPickUp.transform.GetChild(0).transform.rotation = Quaternion.identity;
        }*/
        
        if (Input.GetKeyDown(KeyCode.E) && !hasItem)
        {
            hasItemSO.value = true;
            hasItem = true;

            itemToPickUp.transform.SetParent(hands, true);
            itemToPickUp.GetComponent<Rigidbody>().isKinematic = true;
            itemToPickUp.GetComponent<PickableObject>().playerCollider.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E) && hasItem)
        {
            hasItemSO.value = false;
            hasItem = false;

            itemToPickUp.transform.SetParent(null, true);
            itemToPickUp.GetComponent<Rigidbody>().isKinematic = false;
            itemToPickUp.GetComponent<PickableObject>().playerCollider.SetActive(true);

        }
    }
    
    //to update
    private void ThrowItem()
    {
        if (Input.GetKey(KeyCode.R) && hasItem)
        {
            throwStrenght += (timeToThrow + 1) * Time.deltaTime;

            throwStrSliderGameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.R) && hasItem)
        {
            hasItemSO.value = false;
            hasItem = false;

            itemToPickUp.GetComponent<Rigidbody>().isKinematic = false;
            itemToPickUp.transform.SetParent(null, true);
            itemToPickUp.GetComponent<Rigidbody>().AddForce(transform.forward * throwStrenght, ForceMode.Impulse);
            throwStrSliderGameObject.SetActive(false);
            
            throwStrenght = 0;
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
}