using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BalistaLockOn : MonoBehaviour
{
    public Transform target;

    [Header("Attributes")]

    public float balistaRange = 40f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "enemy";
    public Transform balista;

    public GameObject arrowPrefab;
    public Transform firePoint;

    
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
       
        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
           
        }
        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject arrowGO = (GameObject)Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        //Debug.Log(arrowGO.GetComponent<ArrowScript>());
        var arrow = arrowGO.GetComponent<ArrowScript>();
        if (arrow != null) 
        {
             arrow.Seek(target);
        }
    }
}
