using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
   public Transform enemyPrefab;

   public Transform spawnPoint;

   public float timeBetweenWaves = 5f;
   private float countdown = 1f;

   private int waveIndex = 0;
   void Update ()
   {
        if (countdown <= 0f)
        {
          StartCoroutine(SpawnWave());
          countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime / 2;
   }

   IEnumerator SpawnWave ()
   {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
          SpawnEnemy();
          yield return new WaitForSeconds(2f);
        }
   }
   void SpawnEnemy ()
   {
     Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
   }
}
