using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldChest : MonoBehaviour
{
    [SerializeField]
    public Animator animator;
    public int moneyWorth = 25;
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Helloo");
        if(collider.tag == "player")
        {
            Destroy(gameObject);
            Currency.Money += moneyWorth;
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
