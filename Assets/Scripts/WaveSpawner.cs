using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform fastEnemyPrefab;
    public System.Random ran = new System.Random();
    public Transform spawnPoint;
    
    public bool spawnEnemies = true;

    public float timeBetweenWaves = 5f;
    private float countdown = 1f;

    private int waveIndex = 3;
    void Update ()
    {
        if (countdown <= 0f)
        {
          StartCoroutine(SpawnWave());
          countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime / 2;

        if (Input.GetKeyDown("p"))
        {
            PauseEnemySpawning();
        }
    }

    IEnumerator SpawnWave()
    {
        if(spawnEnemies)
        {
            waveIndex++;
            if (waveIndex < 6)
            {
                for (int i = 0; i < waveIndex; i++)
                {
                    SpawnEnemy();
                    yield return new WaitForSeconds(1f);
                }
            }
            else
            {
                for (int i = 0; i < waveIndex; i++)
                {
                    var randomSpawner = ran.Next(1, 4);

                    if (randomSpawner == 1 || randomSpawner == 2)
                    {
                        SpawnEnemy();
                    }
                    else
                    {
                        SpawnFastEnemy();
                    }
                    yield return new WaitForSeconds(1f);
                    Debug.Log(randomSpawner);
                }
            }
        }
    }

    void SpawnEnemy ()
    {
     Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnFastEnemy ()
    {
      Instantiate(fastEnemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    void PauseEnemySpawning()
    {
        spawnEnemies = !spawnEnemies;
    }
}
