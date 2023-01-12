using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class ShopBlueprint {

    public GameObject prefab;
    public int cost;

    public GameObject fireRateUpgradedPrefab;
    public GameObject rangeUpgradedPrefab;
    public GameObject bothUpgradedPrefab;
    public int upgradeFireRateCost;
    public int upgradeRangeCost;
}
