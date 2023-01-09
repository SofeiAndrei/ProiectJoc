using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject basicBalistaPrefab;

    private ShopBlueprint balistaToBuild;

    public Text NoMoneyMessage;
    private Vector3 NoMoneyMessageSpawn = new Vector3(0f, 40f, 0f);

    public GameObject Canvas;

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
            Text message = Instantiate(NoMoneyMessage, NoMoneyMessageSpawn, Quaternion.Euler(60f, 270f, 0f)) as Text;
            message.transform.SetParent(Canvas.transform, false);

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
