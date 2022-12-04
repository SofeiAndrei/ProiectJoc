using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField]
    private int health = 5;

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("coll");

        if(collider.tag == "enemy")
        {
            health -= 1;
            Debug.Log(health);
            Destroy(collider.gameObject);
        }
    }
    void Update()
    {
    }

    void FixedUpdate(){

    }
}
