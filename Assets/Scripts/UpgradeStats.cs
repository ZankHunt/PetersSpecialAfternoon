using UnityEngine;
using UnityEngine.UI;

public class UpgradeStats : MonoBehaviour {

    public static bool upgradeTower = false;
    public static bool upgradeFisher = false;

    private Color white = Color.white;
    private Color red = Color.red;

    private Image uTB;
    private Image uFB;

    public GameObject upgradeTowerButton;
    public GameObject upgradeFisherButton;

    private bool upgradeReady;

    void Start()
    {
        uTB = upgradeTowerButton.GetComponent<Image>();
        uFB = upgradeFisherButton.GetComponent<Image>();
    }

    void Update()
    {
        if (upgradeReady == true && PlayerStats.Money < 100 && PlayerStats.Fish < 10)
        {
            uTB.color = red;
            uFB.color = red;
            upgradeReady = false;
        } else if (upgradeReady == false && PlayerStats.Money >= 100 && PlayerStats.Fish >= 10)
        {
            uTB.color = white;
            uFB.color = white;
            upgradeReady = true;
        }
    }

    public void UpgradeTower()
    {
        if (PlayerStats.Money >= 100 && PlayerStats.Fish >= 10)
        {
            PlayerStats.Money -= 100;
            PlayerStats.Fish -= 10;
            upgradeTower = true;
        }
    }

    public void UpgradeFisher()
    {
        if (PlayerStats.Money >= 100 && PlayerStats.Fish >= 10)
        {
            PlayerStats.Money -= 100;
            PlayerStats.Fish -= 10;
            upgradeFisher = true;
        }
    }
}