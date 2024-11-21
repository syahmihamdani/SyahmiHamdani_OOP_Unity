using System.Collections;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EnemySpawner[] enemySpawners; 
    public float timer = 0f;           
    [SerializeField] private float waveInterval = 5f; 
    public int waveNumber = 1;         
    public int totalEnemies = 0;         
    private int enemiesSpawnedThisWave = 0;
    void Start()
    {
        StartCoroutine(WaveSystem());
    }

    void Update()
    {
        totalEnemies = CountRemainingEnemies();
    }

    IEnumerator WaveSystem()
    {
        while (true)
        {
            yield return new WaitForSeconds(waveInterval);
            StartNewWave();
        }
    }

    void StartNewWave()
    {
        waveNumber++;
        Debug.Log($"Starting Wave {waveNumber}");

        foreach (EnemySpawner spawner in enemySpawners)
        {
            if (spawner != null)
            {
                spawner.isSpawning = true;
                spawner.defaultSpawnCount = waveNumber; // Increase default spawn count per wave
            }
        }
    }

    public void EnemyDefeated()
    {
        totalEnemies--;
        Debug.Log($"Enemy defeated! Remaining: {totalEnemies}");

        if (totalEnemies <= 0)
        {
            Debug.Log($"Wave {waveNumber} cleared!");
            timer = 0f;
        }
    }

    private int CountRemainingEnemies()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        return enemies.Length;
    }
}
 