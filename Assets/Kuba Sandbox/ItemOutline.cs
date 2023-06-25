using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Outline))]
public class ItemOutline : MonoBehaviour
{
    private Outline _outline;

    public int itemDurability = 4;

    private void Start()
    {
        _outline = GetComponent<Outline>();
        _outline.OutlineMode = Outline.Mode.OutlineVisible;
        _outline.OutlineColor = Color.green;
        _outline.OutlineWidth = 10f;
        _outline.enabled = false;
    }

    private void Update()
    {
        switch (itemDurability)
        {
            case 4:
                _outline.OutlineColor = Color.green;
                break;
            case 3:
                _outline.OutlineColor = Color.yellow;
                break;
            case 2:
                _outline.OutlineColor = Color.magenta;
                break;
            case 1:
                _outline.OutlineColor = Color.red;
                break;
            case 0:
                Destroy(gameObject, 1);
                break;
            default:
                break;
        }

        if (ItemPickup.hasItem)
        {
            ItemPickup.itemToPickUp.GetComponent<Outline>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !ItemPickup.hasItem)
        {
            _outline.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _outline.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Ground" && other.gameObject.tag != "Player")
        {
            itemDurability--;
        }
        
    }
}
