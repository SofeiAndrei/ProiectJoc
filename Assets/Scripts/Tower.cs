using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private int health = 5;
    public HealthBar healthBar;
    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("coll");

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
    }
    void Update()
    {
    }

    void FixedUpdate(){

    }
}
