using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] GroundSpawner groundSpawner;
    [SerializeField] private List<GameObject> obstaclePrefab;
    [SerializeField] private int rangoObstaculoRandom = 1;

    [SerializeField] GameObject foodPrefab;
    [SerializeField] private int foodsToSpawn = 10;

    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {


        // Choose a random point to spawn the obstacle

        // Calculate a random offset relative to the other object's position
        int obstacleSpawnIndex = 2;
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        int auxiliarVeces = 0;
        do
        {
            int xcount = Random.Range(-2, 3) * 2;
            int zcount = Random.Range(-2, 3) * 2;

            Vector3 randomOffset = new Vector3(xcount, 0f, zcount);

            // Spawn the obstacle at the calculated position
            Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Count)], spawnPoint.transform.position + randomOffset, Quaternion.identity, transform);
            auxiliarVeces++; 
        } while(auxiliarVeces < rangoObstaculoRandom);
        // int obstacleSpawnIndex = 2;
        // Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        /*
         // Calculate a random offset relative to the other object's position
         Vector3 randomOffset = new Vector3(Random.Range(-4f, 5f), 0f, Random.Range(-4f, 5f));

         // Spawn the obstacle at the calculated position
         Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Count)], spawnPoint.transform.position + randomOffset, Quaternion.identity, transform);
         */

    }

    public void SpawnFood()
    {
        
        int obstacleSpawnIndex = 2;
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        int auxiliarVeces = 0;
        do
        {
            int xcount = Random.Range(-2, 3) * 2;
            int zcount = Random.Range(-2, 3) * 2;

            Vector3 randomOffset = new Vector3(xcount, 0.2f, zcount);

            // Spawn the obstacle at the calculated position
            Instantiate(foodPrefab, spawnPoint.transform.position + randomOffset, Quaternion.identity, transform);
            auxiliarVeces++;
        } while (auxiliarVeces < foodsToSpawn);
    }

    
}
