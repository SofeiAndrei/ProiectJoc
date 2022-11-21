using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour
{
    public float speed = 0.3f;

    private Vector3 towerCenter = new Vector3(0f, 0f, 0f);

    private Transform currPos;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    void FixedUpdate()
    {
        Vector3 dir = towerCenter - transform.position;
        this.transform.GetComponent<Rigidbody>().AddForce(dir * speed);
        // rb.MovePosition(Vector3.zero);
    }
}
