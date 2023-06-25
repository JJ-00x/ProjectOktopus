using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOutline_Collider : MonoBehaviour
{
    public Outline _outline;
    
    private int itemDurability = 3;

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
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
    
    //interact with player goes off, fix
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Ground" && other.gameObject.tag != "Player")
        {
            itemDurability--;
            Debug.Log(other.gameObject.name);
        }
    }
}
