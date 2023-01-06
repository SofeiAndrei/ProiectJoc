using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    private int wayPointIndex = 0;
    private Transform target;
    public float speed = 0.3f;
    private Vector3 towerCenter = new Vector3(0f, 0f, 0f);

    private Transform currPos;

    void Start()
    {
        target = WayPoints.points[0];
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
    // void FixedUpdate()
    // {
    //     Vector3 dir = towerCenter - transform.position;
    //     this.transform.GetComponent<Rigidbody>().AddForce(dir * speed);
    //     // rb.MovePosition(Vector3.zero);
    // }
}
