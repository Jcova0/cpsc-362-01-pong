using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public float spawnInterval = 1f;
    private float timeSinceLastSpawn = 0f;
    // Q: can you make the walls spawn in a random location every 5 seconds?
    // A: yes, see Update()
    
    // Update is called once per frame
    void Update()
    {
        
        
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f));
            Instantiate(wallPrefab, spawnPos, Quaternion.identity);
            timeSinceLastSpawn = 0f;
            spawnInterval *= 0.9f;
        }
    }
}
