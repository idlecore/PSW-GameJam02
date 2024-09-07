using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedRatio;
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
        Destroy(gameObject);
    }
}
