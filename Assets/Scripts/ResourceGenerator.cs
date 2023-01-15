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
        int square = Random.Range(1,4);
        float xRandom;
        float zRandom;
        switch(square)
        {
            case 1:
                xRandom = Random.Range(-44, -20);
                zRandom = Random.Range(-44, -21);
                break;
            case 2:
                xRandom = Random.Range(-62, -35);
                zRandom = Random.Range(-27, -25);
                break;
            case 3:
                xRandom = Random.Range(-26, -5);
                zRandom = Random.Range(-17, 11);
                break;
            default:
                xRandom = Random.Range(-9, -3);
                zRandom = Random.Range(-11, -29);
                break;
        }
        Vector3 randomSpawnPosition = new Vector3(xRandom, 2, zRandom);
        Instantiate(chestPrefab, randomSpawnPosition, Quaternion.Euler(-90,0,0));
    }
}
