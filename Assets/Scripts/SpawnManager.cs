using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;
    public GameObject spowerup;

    public int enemyCount;
    public int waveNumber = 1;

    private float startDelay = 1.0f;
    private float spowerSpawnTime = 30.0f;

    private float spawnRangeX = 5.0f;
    private float spawnRangeZ = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);
        InvokeRepeating("SpawnSuperPower", startDelay, spowerSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);
        }
    }
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        int randomIndex = Random.Range(0, enemies.Length);
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemies[randomIndex], GenerateSpawnPosition(), enemies[randomIndex].transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        return randomPos;
    }

    void SpawnSuperPower() 
    {
        float spawnPosX = Random.Range(-spawnRangeX, spawnRangeX);
        float spawnPosZ = Random.Range(-spawnRangeZ, spawnRangeZ);

        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);

        Instantiate(spowerup, randomPos, spowerup.gameObject.transform.rotation);
    }
}

