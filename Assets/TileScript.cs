using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Color HoverColor;
    public Vector3 positionOffset;
    public Color WrongHoverColor;
    private Renderer rend;
    private Color startColor;
   
    BuildManager buildManager;

    public GameObject balista;
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
        if (!buildManager.CanBuild)
            return;

        if ((balista != null || transform.position.x < -28) && buildManager.ok == 1)
        {
            Debug.Log("Can't build here");
            return;
        }
        else if (buildManager.ok == 1)
        {
            buildManager.BuildBalistaOn(this);
        }
      
    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
