using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody rb;
    
    float rayCastDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        MouseRayCast();
    }

    private void MovePlayer()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the forward direction based on the player's rotation
        Vector3 movement = transform.forward * verticalInput * moveSpeed;
        Vector3 movementhorizontal = transform.right * horizontalInput * moveSpeed;
        rb.velocity = movementhorizontal;
        rb.velocity = movement;
    }

    private void MouseRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Calculate the direction from the player to the hit point
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f; // Ensure the player stays upright (optional)
            
            // Rotate the player to face the hit point
            if (hit.transform.tag != "Player")
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
