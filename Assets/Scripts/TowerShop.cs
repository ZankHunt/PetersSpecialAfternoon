using UnityEngine;
using UnityEngine.UI;

public class TowerShop : MonoBehaviour {

    BuildManager buildManager;

    public TowerBlueprint tower01;
    public TowerBlueprint tower02;
    public TowerBlueprint tower03;
    public TowerBlueprint tower04;

    public Text towerName;
    public Text towerDamageStat;
    public Text towerSpeedStat;
    public Text towerRangeStat;
    public Text towerMoneyStat;
    public Text towerFishStat;
    public Text towerNote;

    public GameObject tower01Platform;
    public GameObject tower02Platform;
    public GameObject tower03Platform;
    public GameObject tower04Platform;

    private Renderer tower01rend;
    private Renderer tower02rend;
    private Renderer tower03rend;
    private Renderer tower04rend;

    public Color notEnough;
    private Color enoughColor;

    private bool tower01notEnough = false;
    private bool tower02notEnough = false;
    private bool tower03notEnough = false;
    private bool tower04notEnough = false;

    private bool upgraded = false;

    void Start()
    {
        buildManager = BuildManager.instance;
        tower01rend = tower01Platform.GetComponent<Renderer>();
        tower02rend = tower02Platform.GetComponent<Renderer>();
        tower03rend = tower03Platform.GetComponent<Renderer>();
        tower04rend = tower04Platform.GetComponent<Renderer>();
        enoughColor = tower01rend.material.color;
    }

    void Update()
    {
        if(UpgradeStats.upgradeTower == true && upgraded == false)
        {
            tower01.fishCost = 3;
            tower01.moneyCost = 20;
            tower02.fishCost = 4;
            tower02.moneyCost = 30;
            tower03.fishCost = 6;
            tower03.moneyCost = 50;
            tower04.fishCost = 8;
            tower04.moneyCost = 75;
            upgraded = true;
        }
        NotEnoughMoneyForTower();
        EnoughMoneyForTower();
    }

    private void NotEnoughMoneyForTower()
    {
        if (tower01notEnough == false && PlayerStats.Money <= tower01.moneyCost || PlayerStats.Fish <= tower01.fishCost)
        {
            tower01rend.material.color = notEnough;
            tower01notEnough = true;
        }
        if (tower02notEnough == false && PlayerStats.Money <= tower02.moneyCost || PlayerStats.Fish <= tower02.fishCost)
        {
            tower02rend.material.color = notEnough;
            tower02notEnough = true;
        }
        if (tower03notEnough == false && PlayerStats.Money <= tower03.moneyCost || PlayerStats.Fish <= tower03.fishCost)
        {
            tower03rend.material.color = notEnough;
            tower03notEnough = true;
        }
        if (tower04notEnough == false && PlayerStats.Money <= tower04.moneyCost || PlayerStats.Fish <= tower04.fishCost)
        {
            tower04rend.material.color = notEnough;
            tower04notEnough = true;
        }
    }

    private void EnoughMoneyForTower()
    {
        if (PlayerStats.Money >= tower01.moneyCost && PlayerStats.Fish >= tower01.fishCost)
        {
            tower01rend.material.color = enoughColor;
            tower01notEnough = false;
        }
        if (PlayerStats.Money >= tower02.moneyCost && PlayerStats.Fish >= tower02.fishCost)
        {
            tower02rend.material.color = enoughColor;
            tower02notEnough = false;
        }
        if (PlayerStats.Money >= tower03.moneyCost && PlayerStats.Fish >= tower03.fishCost)
        {
            tower03rend.material.color = enoughColor;
            tower03notEnough = false;
        }
        if (PlayerStats.Money >= tower04.moneyCost && PlayerStats.Fish >= tower04.fishCost)
        {
            tower04rend.material.color = enoughColor;
            tower04notEnough = false;
        }
    }

    public void SelectTower01()
    {
        buildManager.SelectTowerToBuild(tower01);
        towerName.text = tower01.prefab.name.ToString();
        towerDamageStat.text = tower01.prefab.GetComponent<Tower>().damage.ToString();
        towerSpeedStat.text = tower01.prefab.GetComponent<Tower>().fireRate.ToString() + "s";
        towerRangeStat.text = tower01.prefab.GetComponent<Tower>().range.ToString() + "m";
        towerMoneyStat.text = tower01.moneyCost.ToString();
        towerFishStat.text = tower01.fishCost.ToString();
        if(UpgradeStats.upgradeTower == true)
        {
            towerDamageStat.text = (tower01.prefab.GetComponent<Tower>().damage * 2).ToString();
        }
        towerNote.enabled = false;
    }
    public void SelectTower02()
    {
        buildManager.SelectTowerToBuild(tower02);
        towerName.text = tower02.prefab.name.ToString();
        towerDamageStat.text = tower02.prefab.GetComponent<Tower>().damage.ToString();
        towerSpeedStat.text = (tower02.prefab.GetComponent<Tower>().fireRate / 100).ToString() + "s";
        towerRangeStat.text = tower02.prefab.GetComponent<Tower>().range.ToString() + "m";
        towerMoneyStat.text = tower02.moneyCost.ToString();
        towerFishStat.text = tower02.fishCost.ToString();
        if (UpgradeStats.upgradeTower == true)
        {
            towerDamageStat.text = (tower02.prefab.GetComponent<Tower>().damage * 2).ToString();
        }
        towerNote.enabled = false;
    }
    public void SelectTower03()
    {
        buildManager.SelectTowerToBuild(tower03);
        towerName.text = tower03.prefab.name.ToString();
        towerDamageStat.text = tower03.prefab.GetComponent<Tower>().damage.ToString();
        towerSpeedStat.text = (tower03.prefab.GetComponent<Tower>().fireRate * 16).ToString() + "s";
        towerRangeStat.text = tower03.prefab.GetComponent<Tower>().range.ToString() + "m";
        towerMoneyStat.text = tower03.moneyCost.ToString();
        towerFishStat.text = tower03.fishCost.ToString();
        if (UpgradeStats.upgradeTower == true)
        {
            towerSpeedStat.text = (tower03.prefab.GetComponent<Tower>().fireRate * 8).ToString() + "s";
        }
        towerNote.enabled = true;
    }
    public void SelectTower04()
    {
        buildManager.SelectTowerToBuild(tower04);
        towerName.text = tower04.prefab.name.ToString();
        towerDamageStat.text = tower04.prefab.GetComponent<Tower>().damage.ToString();
        towerSpeedStat.text = (tower04.prefab.GetComponent<Tower>().fireRate * 25).ToString() + "s";
        towerRangeStat.text = tower04.prefab.GetComponent<Tower>().range.ToString() + "m";
        towerMoneyStat.text = tower04.moneyCost.ToString();
        towerFishStat.text = tower04.fishCost.ToString();
        if (UpgradeStats.upgradeTower == true)
        {
            towerSpeedStat.text = (tower04.prefab.GetComponent<Tower>().fireRate * 12.5f).ToString() + "s";
        }
        towerNote.enabled = false;
    }
}
