using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    [SerializeField] private List<GameObject> obstaclePrefabs;
    [SerializeField] private float spawnRate = 2f;
    [SerializeField] private float laneWidth = 2f;
    [SerializeField] private int minClearLanes = 2;

    private float timeSinceLastSpawn = 0f;

    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnRate)
        {
            timeSinceLastSpawn = 0f;
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        // Determine available lanes
        List<int> availableLanes = new List<int>();
        for (int i = -2; i <= 2; i++)
        {
            availableLanes.Add(i);
        }

        // Remove occupied lanes
        foreach (Transform child in transform)
        {
            int lane = Mathf.RoundToInt(child.position.x / laneWidth);
            if (availableLanes.Contains(lane))
            {
                availableLanes.Remove(lane);
            }
        }

        // Randomly choose a lane from the available ones
        int randomLane = availableLanes[Random.Range(0, availableLanes.Count)];
        // Ensure at least one clear lane
        if (availableLanes.Count < minClearLanes)
        {
            // Randomly choose a lane from the available ones
            
            availableLanes.Clear();
            availableLanes.Add(randomLane);
        }

        // Randomly choose a lane and spawn an obstacle
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        randomLane = availableLanes[randomLaneIndex];

        // Calculate the spawn position
        Vector3 spawnPosition = new Vector3(randomLane * laneWidth, transform.position.y, transform.position.z);

        // Randomly choose an obstacle prefab
        int randomPrefabIndex = Random.Range(0, obstaclePrefabs.Count);
        GameObject obstacle = Instantiate(obstaclePrefabs[randomPrefabIndex], spawnPosition, Quaternion.identity);

        // Make the obstacle a child of the parent object
        
    }
}
