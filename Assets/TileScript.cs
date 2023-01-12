using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TileScript : MonoBehaviour
{
    public Color HoverColor;
    public Vector3 positionOffset;
    public Color WrongHoverColor;
    private Renderer rend;
    private Color startColor;
   
    BuildManager buildManager;
    [HideInInspector]
    public GameObject balista;
    [HideInInspector]
    public ShopBlueprint shopBlueprint;
    [HideInInspector]
    public bool fireRateIsUpgraded = false;
    public bool rangeIsUpgraded = false;
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;

        if ((transform.position.x < -28 || balista != null) && buildManager.ok == 1)
        {
            rend.material.color = WrongHoverColor;
        }
        else if (buildManager.ok == 1)
        {
            rend.material.color = HoverColor;
        }
    }

    void OnMouseDown()
    {

        if (balista != null || transform.position.x < -28)
        {
            //Debug.Log("Can't build here");
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildBalista(buildManager.getBalistaToBuild());
      
    }

    void BuildBalista(ShopBlueprint blueprint)
    {
        if(Currency.Money < blueprint.cost)
        {
            Debug.Log("Not enough money");
            Text message = Instantiate(buildManager.NoMoneyMessage, buildManager.getNoMoneyMessageSpawn(), Quaternion.Euler(60f, 270f, 0f)) as Text;
            message.transform.SetParent(buildManager.Canvas.transform, false);

            buildManager.ok = 0;
            return;
        }
        Currency.Money -= blueprint.cost;

        GameObject _balista = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        balista = _balista;

        shopBlueprint = blueprint;

        buildManager.ok = 0;
    }

    public void upgradeBalistaFireRate()
    {
        if (Currency.Money < shopBlueprint.upgradeFireRateCost)
        {
            Debug.Log("Not enough money");
            Text message = Instantiate(buildManager.NoMoneyMessage, buildManager.getNoMoneyMessageSpawn(), Quaternion.Euler(60f, 270f, 0f)) as Text;
            message.transform.SetParent(buildManager.Canvas.transform, false);

            buildManager.ok = 0;
            return;
        }
        Currency.Money -= shopBlueprint.upgradeFireRateCost;

        //Sterge balista veche
        Destroy(balista);

        //O instantiaza pe cea noua
        if(!fireRateIsUpgraded && !rangeIsUpgraded)
        {
            GameObject _balista = (GameObject)Instantiate(shopBlueprint.fireRateUpgradedPrefab, GetBuildPosition(), Quaternion.identity);
            balista = _balista;
            buildManager.ok = 0;
        }

        else if(!fireRateIsUpgraded && rangeIsUpgraded)
        {
            GameObject _balista = (GameObject)Instantiate(shopBlueprint.bothUpgradedPrefab, GetBuildPosition(), Quaternion.identity);
            balista = _balista;
            buildManager.ok = 0;
        }

        else
        {
            return;
        }

        fireRateIsUpgraded = true;

    }

    public void upgradeBalistaRange()
    {
        if (Currency.Money < shopBlueprint.upgradeRangeCost)
        {
            Debug.Log("Not enough money");
            Text message = Instantiate(buildManager.NoMoneyMessage, buildManager.getNoMoneyMessageSpawn(), Quaternion.Euler(60f, 270f, 0f)) as Text;
            message.transform.SetParent(buildManager.Canvas.transform, false);

            buildManager.ok = 0;
            return;
        }
        Currency.Money -= shopBlueprint.upgradeRangeCost;

        //Sterge balista veche
        Destroy(balista);

        //O instantiaza pe cea noua
        if (!fireRateIsUpgraded && !rangeIsUpgraded)
        {
            GameObject _balista = (GameObject)Instantiate(shopBlueprint.rangeUpgradedPrefab, GetBuildPosition(), Quaternion.identity);
            balista = _balista;
            buildManager.ok = 0;
        }

        else if (fireRateIsUpgraded && !rangeIsUpgraded)
        {
            GameObject _balista = (GameObject)Instantiate(shopBlueprint.bothUpgradedPrefab, GetBuildPosition(), Quaternion.identity);
            balista = _balista;
            buildManager.ok = 0;
        }

        else
        {
            return;
        }

        rangeIsUpgraded = true;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
