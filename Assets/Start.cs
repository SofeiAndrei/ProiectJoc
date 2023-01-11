using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
    public EnemyTowerScript enemyTower;
   
    void Update()
    {
        if(enemyTower.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
