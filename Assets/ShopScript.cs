using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public ShopBlueprint balista;
    public ShopBlueprint soldier;
    public ShopBlueprint tower;
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
    public void PurchaseSoldier()
    {
        buildManager.SpawnSoldier(soldier);
    }
    public void RepairTower()
    {
        buildManager.RepairTower(tower);
    }

}
