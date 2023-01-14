using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;

    public int damage = 50;

    public void Seek(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
       // Quaternion lookRotation = Quaternion.LookRotation(dir);
        //Vector3 rotation = lookRotation.eulerAngles;
        //transform.rotation = Quaternion.Euler(0f, rotation.y + 180f, 0f);
    }

    void HitTarget()
    {
        Damage(target);
        Destroy(gameObject);
        
    }

    void Damage(Transform enemy)
    {
        var e = enemy.GetComponent<BadGuy>();

        if (e != null)
        {
            if(e.isAttacking == false)
            {
                e.TakeDamage(damage);
            }
        }
    }

}
