using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public ShopBlueprint balista;
    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PurchaseBalista()
    {
        buildManager.ok = 1;
        buildManager.SelectBalistaToBuild(balista);
    }
        
}
