using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public static int Money;
    public int startMoney = 200;

    void Start()
    {
        Money = startMoney;
    }
}
