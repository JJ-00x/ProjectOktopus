using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bilboard : MonoBehaviour
{
    public Transform cam;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
