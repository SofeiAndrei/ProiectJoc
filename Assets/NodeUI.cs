using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;

    private TileScript target;

    public void SetTarget(TileScript _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if(target.balista != null)
            ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void UpgradeFireRate()
    {
        target.UpgradeBalistaFireRate();
        BuildManager.instance.DeselectNode();
    }

    public void UpgradeRange()
    {
        target.UpgradeBalistaRange();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellBalista();
        BuildManager.instance.DeselectNode();
    }

}
