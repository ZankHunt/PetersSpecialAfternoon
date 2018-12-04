using UnityEngine;

public class Node : MonoBehaviour {

    [Header("Unity Setup")]
    public Color hoverColor;
    public Color notEnoughMoneyColour;
    public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject tower;

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

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

    void OnMouseDown()
    {
        if (!buildManager.CanBuild)
            return;

        if (tower != null)
        {
            return;
        }

        buildManager.BuildTowerOn(this);
    }

    void OnMouseEnter()
    {
        if (!buildManager.CanBuild)
            return;
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColour;
        }

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
