using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    public GameObject basicBalistaPrefab;
    public Tower myTower;

    private ShopBlueprint balistaToBuild;

    public Text NoMoneyMessage;
    public Text TowerHealthMessage;
    private Vector3 NoMoneyMessageSpawn = new Vector3(0f, 40f, 0f);

    public GameObject Canvas;

    public int ok = 0;

    public Transform soldierPrefab;
    public Transform spawnPoint;
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
        get { return balistaToBuild != null; }
    }
    public void BuildBalistaOn(TileScript tile)
    {
        if (Currency.Money < balistaToBuild.cost)
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

    public void SpawnSoldier(ShopBlueprint soldier)
    {
        if (Currency.Money < soldier.cost)
        {
            Debug.Log("Not enough money");
            Text message = Instantiate(NoMoneyMessage, NoMoneyMessageSpawn, Quaternion.Euler(60f, 270f, 0f)) as Text;
            message.transform.SetParent(Canvas.transform, false);
            return;
        }
        else
        {
            Vector3 correctSpawnPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 1, spawnPoint.position.z);
            Instantiate(soldierPrefab, correctSpawnPosition, Quaternion.Euler(0f, 0f, 0f));
            Currency.Money -= soldier.cost;
        }
    }
    public void RepairTower(ShopBlueprint tower)
    {
        if (Currency.Money < tower.cost)
        {
            Debug.Log("Not enough money");
            Text message = Instantiate(NoMoneyMessage, NoMoneyMessageSpawn, Quaternion.Euler(60f, 270f, 0f)) as Text;
            message.transform.SetParent(Canvas.transform, false);
            return;
        }
        else
        {
            myTower = tower.prefab.GetComponent<Tower>();
            if (myTower.health == myTower.initialHealth)
            {
                Debug.Log("Tower health already full");
                Text message = Instantiate(TowerHealthMessage, NoMoneyMessageSpawn, Quaternion.Euler(60f, 270f, 0f)) as Text;
                message.transform.SetParent(Canvas.transform, false);
            }
            else
            if ((myTower.health + 2) > myTower.initialHealth)
            {
                myTower.health = myTower.initialHealth;
                myTower.healthBar.SetHealth(myTower.health);
                Currency.Money -= tower.cost;
            }
            else
            {
                myTower.health += 2;
                myTower.healthBar.SetHealth(myTower.health);
                Currency.Money -= tower.cost;
            }

        }
    }
}
