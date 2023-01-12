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

        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void UpgradeFireRate()
    {
        target.upgradeBalistaFireRate();
        BuildManager.instance.DeselectNode();
    }

    public void UpgradeRange()
    {
        target.upgradeBalistaRange();
        BuildManager.instance.DeselectNode();
    }

}
