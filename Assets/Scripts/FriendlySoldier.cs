using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlySoldier : MonoBehaviour
{
    private int wayPointIndex;
    private Transform target;
    public float speed = 0.3f;
    private Vector3 towerCenter = new Vector3(0f, 0f, 0f);
    private bool isAttacking = false;
    Collider m_Collider;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        target = WayPoints.points[WayPoints.points.Length - 2];
        wayPointIndex = WayPoints.points.Length - 1;
        animator = this.GetComponent<Animator>();
        m_Collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAttacking)
        {
            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            if (Vector3.Distance(transform.position, target.position) <= 0.5f)
            {
                GetNextWayPoint();
            }
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

    public IEnumerator OnTriggerEnter(Collider collider)
    {
       
        if(collider.tag == "enemy")
        {
            isAttacking = true;
            animator.SetInteger("isAttacking", 1);
            
            m_Collider.enabled = false;
            yield return new WaitForSeconds(1.5f);
            animator.SetInteger("isDying", 1);
            yield return new WaitForSeconds(1.5f);
            Die();
            Destroy(collider.gameObject);
            


        }
    }
    
    void Die()
    {
        Destroy(gameObject);
    }
}
