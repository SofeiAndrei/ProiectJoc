using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBalista : MonoBehaviour
{
    public Tower tower;
    public Player player;
    void Update()
    {
        if(tower.health <= 0 || player.health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
