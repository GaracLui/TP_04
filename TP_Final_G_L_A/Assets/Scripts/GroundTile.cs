using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] GroundSpawner groundSpawner;
    [SerializeField] private List<GameObject> obstaclePrefab;
    [SerializeField] private int rangoObstaculoRandom = 1;




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

        //Transform spawnPoint = transform.GetChild(2).transform;
        // Choose a random point to spawn the obstacle
        //for (int a = -4; a < 5; a = +2)
        //{
            /*
            int azarEnX = Random.Range(0, rangoObstaculoRandom + 1);
            for (int b = 0; b < (azarEnX + 1); b = +2)
            {
                int azarDentroDeX = Random.Range(-2, 3);
                Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Count)], spawnPoint.position, Quaternion.identity, transform);
            }
            */
        



            int obstacleSpawnIndex = 2;
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

            // Calculate a random offset relative to the other object's position
            Vector3 randomOffset = new Vector3(Random.Range(-4f, 5f), 0f, Random.Range(-4f, 5f));

            // Spawn the obstacle at the calculated position
            Instantiate(obstaclePrefab[Random.Range(0, obstaclePrefab.Count)], spawnPoint.transform.position + randomOffset, Quaternion.identity, transform);
        //}


    }

}
