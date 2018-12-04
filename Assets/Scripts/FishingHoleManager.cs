using UnityEngine;
using UnityEngine.UI;

public class FishingHoleManager : MonoBehaviour {

    public static FishingHoleManager instance;

    private void Awake()
    {
        instance = this;
    }

    public static bool fishSpawned;

    public FishBlueprint fish01;
    public FishBlueprint fish02;

    private FishBlueprint fishToSpawn;

    public Text fishingInfo;

    public GameObject fishI;
    public GameObject fishE;

    private bool upgraded = false;

    void Start()
    {
        fishSpawned = false;
    }

    void Update()
    {
        if (upgraded == false && UpgradeStats.upgradeFisher == true)
        {
            fish01.value = fish01.value * 2;
            fish01.chance += 15;
            fish02.value = fish02.value * 2;
            fish02.chance += 15;
            upgraded = true;
        }
    }

    public void GetFish()
    {
        fishE.SetActive(false);
        SelectFish();
        float random = Random.Range(0f, 100f);
        if (fishToSpawn.chance > random)
        {
            AudioManager.instance.Play("CaughtFish");
            fishingInfo.text = "You got a " + fishToSpawn.name + "!";
            fishI.SetActive(true);
            PlayerStats.Fish += fishToSpawn.value;
        } else
        {
            AudioManager.instance.Play("FishGotAway");
            fishingInfo.text = "The fish got away!";
            fishI.SetActive(true);
        }
    }

    private void SelectFish()
    {
        int fish = 2;
        int selectFish = Random.Range(0, fish);
        if (selectFish == 0)
        {
            fishToSpawn = fish01;
            return;
        }
        if (selectFish == 1)
        {
            fishToSpawn = fish02;
            return;
        }
    }
}
