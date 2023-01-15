using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    public int health = 15;
    public int initialHealth;
    public HealthBar healthBar;
    public Player player;
    public void OnTriggerEnter(Collider collider)
    {
       
        if(collider.tag == "enemy")
        {
            health -= 1;
            healthBar.SetHealth(health);

            Destroy(collider.gameObject);
        }
    }

    void Start()
    {
        healthBar.SetMaxHealth(health);
        initialHealth = health;
    }
    void Update()
    {
        if (health <= 0 || player.health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate(){

    }
}
