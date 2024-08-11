using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Time interval between spawns
    public float startTimeBtwSpawn;
    // Timer to track time between spawns
    private float timeBtwSpawn;

    // Array of enemy prefabs to spawn
    public GameObject[] enemies;

    private void Update()
    {
        // Check if the timer has reached zero
        if (timeBtwSpawn <= 0)
        {
            // Instantiate a random enemy from the array at the spawner's position
            Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
            // Reset the timer to the start time
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            // Decrease the timer by the time elapsed since the last frame
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
