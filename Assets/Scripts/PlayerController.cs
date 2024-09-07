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
    public GameObject bulletPrefab;
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

    public void OnFire(InputValue value)
    {
        GameObject newBullet = GameObject.Instantiate(bulletPrefab);
        newBullet.transform.rotation = gun.transform.rotation; // Makes the bullet face the same way as the gun
        newBullet.transform.position += newBullet.transform.up * 1.1f; // Makes the bullet look like it spawned under the gun
    }
}
