using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlySoldier : MonoBehaviour
{
    private int wayPointIndex;
    private Transform target;
    public float speed = 0.3f;
    private Vector3 towerCenter = new Vector3(0f, 0f, 0f);
    // Start is called before the first frame update
    void Start()
    {
        target = WayPoints.points[WayPoints.points.Length - 2];
        wayPointIndex = WayPoints.points.Length - 1;
    }

    // Update is called once per frame
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
        if (wayPointIndex == WayPoints.points.Length - 2 || wayPointIndex == WayPoints.points.Length - 4)
        {
            transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
        }
        else
        if (wayPointIndex == WayPoints.points.Length - 3)
        {
            transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
        }
        
        if (wayPointIndex <= 0)
        {
            Destroy(gameObject);
            return;
        }
        wayPointIndex--;
        target = WayPoints.points[wayPointIndex];
    }

    public void OnTriggerEnter(Collider collider)
    {
        Debug.Log("coll with enemy soldier");

        if(collider.tag == "enemy")
        {
            Destroy(collider.gameObject);
            Die();
        }
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
}
