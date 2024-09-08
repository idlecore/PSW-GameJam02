using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public float speedRatio;
    public UnityAction<uint> deathAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.position * speedRatio * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided - Enemy");
        // When we hit something destroy ourselves
        deathAction.Invoke(1);
        Destroy(gameObject);
    }
}
