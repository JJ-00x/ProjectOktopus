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



    private void PickUpDropItem()
    {
        if (itemToPickUp == null)
        {
            hasItem = false;
            return;
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
        if (Input.GetKey(KeyCode.R) && hasItemSO.value)
        {
            throwStrenght += (timeToThrow + 1) * Time.deltaTime;

            throwStrSliderGameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.R) && hasItemSO.value)
        {
            hasItemSO.value = false;
            hasItem = false;

            itemToPickUp.GetComponent<Rigidbody>().isKinematic = false;
            itemToPickUp.GetComponent<Rigidbody>().AddForce(transform.forward * throwStrenght, ForceMode.Impulse);
            itemToPickUp.transform.SetParent(null, true);
            throwStrenght = 0;

            throwStrSliderGameObject.SetActive(false);
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
            itemToPickUp = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PickUp" && !hasItemSO.value)
        {
            Debug.Log("item collide:" + other.gameObject.name);
            itemToPickUp = null;
        }
    }
}