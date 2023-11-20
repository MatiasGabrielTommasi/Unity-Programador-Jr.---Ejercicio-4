using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    float spawnRange = 9.0f;
    int enemyCount = 0;
    int waveNumber = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void EnemySpawnWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
            EnemySpawnWave(waveNumber);
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(spawnRange - spawnRange, spawnRange);
        float spawnPosZ = Random.Range(spawnRange - spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
