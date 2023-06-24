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

    private bool hasItem;
    
    public float throwStrenght = 0f;
    public float maxthrowStrenght = 15f;
    public float timeToThrow = 1;

    public GameObject throwStrSliderGameObject;
    public Slider throwStrSlider;
    public Gradient throwColor;
    public Image fill;
    [SerializeField] private ScriptableObjectBOOL hasItemSO;
    
    private void Start()
    {
        hasItem = false;
        throwStrSliderGameObject.SetActive(false);
    }

    private void Update()
    {
        //object interaction
        PickUpDropItem();
        hasItemSO.value = hasItem;
        ThrowItem();
        
        //slider
        ThrowSlider();
        SetMaxThrowStrenght();
        Debug.Log(hasItem);
    }
    
    private void ThrowItem()
    {
        if (Input.GetKey(KeyCode.R) && hasItem)
        {
            throwStrenght += (timeToThrow + 1) * Time.deltaTime;

            throwStrSliderGameObject.SetActive(true);
        }

        if (Input.GetKeyUp(KeyCode.R) && hasItem)
        {
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
        if (Input.GetKeyDown(KeyCode.E) && !hasItem)
        {
            hasItem = true;

            itemToPickUp.transform.SetParent(hands, true);
            itemToPickUp.transform.position = hands.transform.position;

            itemToPickUp.transform.rotation = Quaternion.identity;

            Destroy(itemToPickUp.GetComponent<Rigidbody>());
        }
        else if (Input.GetKeyDown(KeyCode.E) && hasItem)
        {
            hasItem = false;
            AddRigidbody();

            itemToPickUp.transform.SetParent(null, true);
        }
    }

    private void ThrowSlider()
    {
        throwStrSlider.maxValue = 10f;
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
