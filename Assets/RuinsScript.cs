using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuinsScript : MonoBehaviour
{
    public static RuinsScript instance;
    void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
