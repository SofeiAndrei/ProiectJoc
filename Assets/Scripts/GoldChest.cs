using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldChest : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    public int moneyWorth = 25;

    public GameObject moneyUI;

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Helloo");
        if(collider.tag == "player")
        {
            Destroy(gameObject);
            Currency.Money += moneyWorth;
            var _moneyUI = moneyUI.GetComponent<MoneyUI>();
            _moneyUI.KilledEnemies(moneyWorth);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
