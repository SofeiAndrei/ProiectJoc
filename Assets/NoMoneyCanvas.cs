using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoMoneyCanvas : MonoBehaviour
{
    private float countdown = 2f;

    
    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0f && gameObject != null)
        {
            Destroy(gameObject);
            countdown = 2f;
        }
        countdown -= Time.deltaTime;
    }
}
