using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpMode : MonoBehaviour
{
    // Initial time interval between spawns
    public float startTimeBtwSpawn;
    // Time interval in seconds to decrease spawn time
    public float decreaseInterval = 10f;
    // Amount to decrease the spawn time by
    public float decreaseAmount = 0.1f;
    // Minimum spawn time limit
    public float minSpawnTime = 0.5f;

    // Timer to track time between spawns
    private float timeBtwSpawn;

    // Array of enemy prefabs to spawn
    public GameObject[] enemies;

    private void Start()
    {
        // Initialize the timer with the starting spawn time
        timeBtwSpawn = startTimeBtwSpawn;
        // Start the coroutine to decrease spawn time over intervals
        StartCoroutine(DecreaseSpawnTime());
    }

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

    // Coroutine to decrease the spawn time at regular intervals
    private IEnumerator DecreaseSpawnTime()
    {
        while (true)
        {
            // Wait for the specified interval before decreasing the spawn time
            yield return new WaitForSeconds(decreaseInterval);

            // Decrease the spawn time but ensure it doesn't go below the minimum
            startTimeBtwSpawn = Mathf.Max(minSpawnTime, startTimeBtwSpawn - decreaseAmount);
        }
    }
}
