using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 2f;
    private float timeout = 0;

    // Start is called before the first frame update
    void Start()
    {
        timeout = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;

        // If we are no longer on screen destroy ourselves
        // NOTE: This is going to have a lot of overhead. If performance becomes an issue,
        // we should create a bullet pool instead of creating/destroying
        Debug.Log(Time.time +" - " + timeout);
        if (Time.time >= timeout && !GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
        
    }
}
