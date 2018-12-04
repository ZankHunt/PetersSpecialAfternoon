using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public static int Fish;
    public static int Lives;
    public int startMoney = 100;
    public int startFish = 10;
    public int startLives = 1;

    public Text fishStat;
    public Text moneyStat;

    void Start()
    {
        Money = startMoney;
        Fish = startFish;
        Lives = startLives;
    }

    void Update()
    {
        moneyStat.text = Money.ToString();
        fishStat.text = Fish.ToString();
    }
}
