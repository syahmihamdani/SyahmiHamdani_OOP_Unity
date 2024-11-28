using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public GameObject spawnedEnemyPrefab; 
    public Transform[] spawnPoints;   

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    private int totalKillWave = 0;

    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;

    public CombatManager combatManager;

    public bool isSpawning = false;

    void Start()
    {
        // Start spawning enemies
        StartCoroutine(SpawnEnemies());
    }

    void Update()
    {
        if (totalKill >= minimumKillsToIncreaseSpawnCount * multiplierIncreaseCount)
        {
            multiplierIncreaseCount++;
            spawnCountMultiplier++;
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (isSpawning)
            {
                SpawnEnemyWave();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnEnemyWave()
    {
        int enemiesToSpawn = defaultSpawnCount * spawnCountMultiplier;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            if (spawnPoints.Length > 0)
            {
               Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                Instantiate(spawnedEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
                spawnCount++;
            }
        }
    }

    public void EnemyKilled()
    {
        totalKill++;
        totalKillWave++;
    }
}