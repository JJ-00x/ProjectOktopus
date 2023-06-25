using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    [SerializeField] private ScriptableObjectBOOL hasItem;
    [SerializeField] private ScriptableObjectINT speed;
    public float moveSpeed = 5f;

    private Rigidbody rb;
    
    float rayCastDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (hasItem.value == false)
        {
            moveSpeed = 5f;
        }
        else if (hasItem.value)
        {
            moveSpeed = speed.value;
        }

        MouseRayCast();
        
        if (rayCastDistance > 2)
        {
            MovePlayer();
        }

    }

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput * moveSpeed;
        rb.velocity = movement;
    }

    public LayerMask LayerMask;
    private void MouseRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask))
        {
            // Calculate the direction from the player to the hit point
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f; // Ensure the player stays upright (optional)
            
            // Rotate the player to face the hit point
            if (hit.transform.tag != "Player")
            {
                transform.forward = direction;
            }

            rayCastDistance = Vector3.Distance(transform.position, hit.point);
            //Debug.Log(rayCastDistance);
        }
    }
}
