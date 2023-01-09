using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceGenerator : MonoBehaviour
{
    public Transform chestPrefab;
    private GameObject[] getCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnChest();
    }

    // Update is called once per frame
    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("gold");
        if(getCount.Length == 0)
        {
            SpawnChest();
        }
    }

    void SpawnChest()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-60, -10), 2, Random.Range(-45, -40));
        Instantiate(chestPrefab, randomSpawnPosition, Quaternion.Euler(-90,0,0));
    }
}
