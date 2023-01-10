using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTower : MonoBehaviour
{
    [SerializeField]
    public int health = 15;
    public HealthBar healthBar;
    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("enemy tower coll");

        if(collider.tag == "friendly_soldier")
        {
            health -= 1;
            healthBar.SetHealth(health);

            Destroy(collider.gameObject);
        }
    }

    void Start()
    {
        healthBar.SetMaxHealth(health);
    }
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate(){

    }
}
