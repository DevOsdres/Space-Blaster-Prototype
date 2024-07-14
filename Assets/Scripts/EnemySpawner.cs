using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnX = 70;
    private float spawnZ = 80;
    private float spawnY = 5f;
    private float spawnDelay = 2f;
    private float spawnInterval = 1.5f;

    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", spawnDelay, spawnInterval);
    }

    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0,enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnX, spawnX), spawnY, spawnZ);
        Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
