/*
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemOutline_Collider : MonoBehaviour
{
    public Outline _outline;
    [SerializeField] private ScriptableObjectBOOL isdestroyed;

    public int itemDurability = 3;

    private void Start()
    {
        _outline = GetComponentInParent<Outline>();
    }

    private void Update()
    {
        switch (itemDurability)
        {
            case 3:
                _outline.OutlineColor = Color.green;
                break;
            case 2:
                _outline.OutlineColor = Color.yellow;
                break;
            case 1:
                _outline.OutlineColor = Color.red;
                break;
            case 0:
                isdestroyed.value = true;
                break;
            default:
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Ground" && other.gameObject.tag != "Player")
        {
            Debug.Log("Itemdurability");
            itemDurability--;
            Debug.Log(other.gameObject.name);
        }
    }
    
    //interact with player goes off, fix
    /*private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Ground" || other.gameObject.tag != "Player")
        {
            Debug.Log("Itemdurability");
            itemDurability--;
            Debug.Log(other.gameObject.name);
        }
    }#1#
}
*/
