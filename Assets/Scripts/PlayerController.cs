using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameObject gun;
    public float rotationSpeed = 1;
    public float rotationAcceleration = 1;
    public float frictionConstant = 1;
    private float currentRotationValue = 0;
    private float currentRotationSpeed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        currentRotationSpeed += currentRotationValue * rotationAcceleration;
        if (currentRotationSpeed != 0)
        {
            currentRotationSpeed -= currentRotationSpeed > 0 ? frictionConstant : -frictionConstant;
        }
        currentRotationSpeed = Math.Clamp(currentRotationSpeed, -rotationSpeed, rotationSpeed);
        gun.transform.Rotate(0f, 0f, currentRotationSpeed);

    }

    public void OnRotate(InputValue value)
    {
        Debug.Log(value);
        currentRotationValue = -1 * value.Get<float>();
    }
}
