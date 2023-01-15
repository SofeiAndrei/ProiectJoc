using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalistaMoney : MonoBehaviour
{
    public Text moneyText;
    private static int balistaValue = 50;

    void Update()
    {
        moneyText.text = balistaValue.ToString();
    }

    public void BalistaUpgraded(int _moneyToGain)
    {
        balistaValue = _moneyToGain;
    }
}
