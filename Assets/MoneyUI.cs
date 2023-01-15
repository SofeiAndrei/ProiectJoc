
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;
    private static int killedAnEnemy = 0;
    private static int soldBalista = 0;
    private static int moneyGained = 0;
    private float countdown = 1f;

    // Update is called once per frame
    void Update()
    {
        if (killedAnEnemy == 1 || soldBalista == 1)
        {
            moneyText.text =  Currency.Money.ToString() + " +" + moneyGained.ToString();
            if (countdown <= 0f)
            {
                killedAnEnemy = 0;
                countdown = 1f;
            }
            countdown -= Time.deltaTime;
        }
        else
        {
            moneyText.text = Currency.Money.ToString();
        }
   
    }
    public void KilledEnemies(int _moneyGained)
    {
        killedAnEnemy = 1;
        moneyGained = _moneyGained;
    }
    public void SoldBalista(int _moneyGained)
    {
        soldBalista = 1;
        moneyGained = _moneyGained;
    }
}