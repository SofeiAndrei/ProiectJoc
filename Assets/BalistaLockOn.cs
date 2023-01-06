using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalistaLockOn : MonoBehaviour
{
    public Transform target;
    public float balistaRange = 40f;
    public string enemyTag = "enemy";
    public Transform balista;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistanceToEnemy = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistanceToEnemy)
            {
                shortestDistanceToEnemy = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistanceToEnemy <= balistaRange)
        {
            target = nearestEnemy.transform;
            Debug.Log("Muie");
        } else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            return;
        }
        
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = lookRotation.eulerAngles;
        balista.rotation = Quaternion.Euler(0f, rotation.y + 180f, 0f);
    }
}
