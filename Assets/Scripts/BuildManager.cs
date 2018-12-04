using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject tower01Prefab;
    public GameObject tower02Prefab;
    public GameObject tower03Prefab;
    public GameObject tower04Prefab;

    private TowerBlueprint towerToBuild;

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.moneyCost && PlayerStats.Fish >= towerToBuild.fishCost; } }

    public void BuildTowerOn(Node node) {

        if(PlayerStats.Money < towerToBuild.moneyCost || PlayerStats.Fish < towerToBuild.fishCost)
            return;

        PlayerStats.Money -= towerToBuild.moneyCost;
        PlayerStats.Fish -= towerToBuild.fishCost;

        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.tower = tower;
    }

    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
    }
}
