using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRadius;
    public float spawnRate = 1;
    public GameObject enemyPrefab;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            timer = 0;
            spawnEnemy();
        }
    }

    private void spawnEnemy()
    {
        Debug.Log("Spawning Enemy");
        GameObject newEnemy = GameObject.Instantiate(enemyPrefab);
        newEnemy.transform.parent = gameObject.transform;

        // Generate a random angle (in radians).
        // We can think of this as a point on a polar plane.
        // Convert this point to a point on a cartesian plane where the
        // radius of the polar is spawnRadius.
        // Convert this point to screenspace coordinates.
        float angle = UnityEngine.Random.Range(0f, (float)(Math.PI*2f));
        newEnemy.transform.position = polarToCart(angle);
        newEnemy.GetComponent<Enemy>().deathAction += GameController.instance.addToScore;
    }

    private Vector2 polarToCart(float angle)
    {
        float x = spawnRadius * (float)Math.Cos(angle);
        float y = spawnRadius * (float)Math.Sin(angle);
        return new Vector2(x,y);
    }

}
