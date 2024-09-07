using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    private float timeout = 0;
    // Start is called before the first frame update
    void Start()
    {
        timeout = Time.time + 1;
    }

    // Update is called once per frame
    void Update()
    {
        // If we are no longer on screen destroy ourselves
        // NOTE: This is going to have a lot of overhead. If performance becomes an issue,
        // we should create a bullet pool instead of creating/destroying
        if (Time.time >= timeout && !GetComponent<SpriteRenderer>().isVisible)
        {
            Destroy(gameObject);
        }
    }
}
