using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOutline_Trigger : MonoBehaviour
{
    public Outline _outline;
    private void Start()
    {
        _outline = GetComponentInParent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        _outline.OutlineColor = Color.green;
        _outline.OutlineWidth = 10f;
        _outline.enabled = false;
    }

    private void Update()
    {
        if (ItemPickup.hasItem)
        {
            ItemPickup.itemToPickUp.GetComponent<Outline>().enabled = true;
        }

        if (ItemPickup.itemToPickUp == null)
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !ItemPickup.hasItem)
        {
            Debug.Log(other.name);
            _outline.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _outline.enabled = false;
        }
    }
}
