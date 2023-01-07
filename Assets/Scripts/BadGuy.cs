using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BadGuy : MonoBehaviour
{
    public float startHealth = 100;
    private float health;
    public Image healthBar;

    private int wayPointIndex = 0;
    private Transform target;
    public float speed = 0.3f;
    private Vector3 towerCenter = new Vector3(0f, 0f, 0f);

    private Transform currPos;

    void Start()
    {
        target = WayPoints.points[0];
        health = startHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }
    }

        void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            GetNextWayPoint();
        }
    }
    void GetNextWayPoint()
    {
        if (wayPointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        wayPointIndex++;
        target = WayPoints.points[wayPointIndex];
    }

    void Die()
    {
        Destroy(gameObject);
    }

        // void FixedUpdate()
        // {
        //     Vector3 dir = towerCenter - transform.position;
        //     this.transform.GetComponent<Rigidbody>().AddForce(dir * speed);
        //     // rb.MovePosition(Vector3.zero);
        // }
}
