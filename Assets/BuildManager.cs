using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject basicBalistaPrefab;

    private ShopBlueprint balistaToBuild;

    public int ok = 0;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public bool CanBuild
    {
        get{ return balistaToBuild != null; }
    }
    public void BuildBalistaOn(TileScript tile)
    {
        if(Currency.Money < balistaToBuild.cost)
        {
            Debug.Log("Not enough money");
            ok = 0;
            return;
        }
        Currency.Money -= balistaToBuild.cost;
        GameObject balista = (GameObject)Instantiate(balistaToBuild.prefab, tile.GetBuildPosition(), Quaternion.identity);
        tile.balista = balista;
        ok = 0;
    }
    public void SelectBalistaToBuild(ShopBlueprint balista)
    {
        balistaToBuild = balista;
    }

}
