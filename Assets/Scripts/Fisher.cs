using UnityEngine;
using UnityEngine.UI;

public class Fisher : MonoBehaviour {

    private Transform fisherSpots;
    public static int fisherSpotsIndex = 0;

    private float buttonCooldown = 1f;
    private float fishingCountdown = 3f;
    private float buttonPressCountdown = 2f;
    private float resetHUD = 2f;
    public static bool fishing;
    private bool sound = false;

    public Text fishingEffect;

    public GameObject fishI;
    public GameObject fishE;

    FishingHoleManager fishingHoleManager;

    void Start ()
    {
        fisherSpots = FisherSpots.spots[fisherSpotsIndex];
        fishingHoleManager = FishingHoleManager.instance;
        fishing = false;
    }

    void Update () {
        if(GameManager.gameEnd == true)
        {
            fishing = false;
            enabled = false;
        }
        if(fishing == true)
        {
            if(sound == false)
            {
                AudioManager.instance.Play("Fishing");
                sound = true;
            }
            FishingCountdown();
            if (fishingCountdown <= 0)
            {
                fishingEffect.text = "!";
                ButtonPressCountdown();
            }
            return;
        }
        resetHUD -= Time.deltaTime;
        Vector3 pos = fisherSpots.position - transform.position;
        transform.Translate(pos, Space.World);
        buttonCooldown -= Time.deltaTime;
        Movement();
        Actions();
        if(resetHUD <= 0)
        {
            AudioManager.instance.Stop("FishGotAway");
            AudioManager.instance.Stop("CaughtFish");
            fishI.SetActive(false);
            fishE.SetActive(false);
        }
	}

    void FishingCountdown()
    {
        fishingCountdown -= Time.deltaTime;
        AudioManager.instance.Stop("FishGotAway");
        AudioManager.instance.Stop("CaughtFish");
        fishingEffect.text = ".";
        fishI.SetActive(false);
        fishE.SetActive(true);
        if (fishingCountdown <= 2)
        {
            fishingEffect.text = "..";
        }
        if(fishingCountdown <= 1)
        {
            fishingEffect.text = "...";
        }
    }

    void ButtonPressCountdown()
    {
        buttonPressCountdown -= Time.deltaTime;
        if (buttonPressCountdown <= 0)
        {
            fishingCountdown = 3f;
            buttonPressCountdown = 1f;
            FishingHole.fishThere = 0f;
            fishing = false;
            fishE.SetActive(false);
            resetHUD = 2f;
            sound = false;
            return;
        }
        if (Input.GetButtonDown("Fishing"))
        {
            FishingAction();
            fishE.SetActive(false);
            resetHUD = 2f;
            sound = false;
            return;
        }
    }

    void Movement()
    {
        if (buttonCooldown <= 0.75f)
        {
            if (Input.GetAxisRaw("Vertical") > 0.5f)
            {
                buttonCooldown = 1f;
                NextFisherSpot(1);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.5f)
            {
                buttonCooldown = 1f;
                NextFisherSpot(-1);
            }
        }
    }
    
    void Actions()
    {
        if (FishingHole.fisherThere == true && Input.GetButtonDown("Fishing"))
        {
            fishing = true;
        }
    }

    void FishingAction()
    {
        fishingHoleManager.GetFish();
        FishingHole.fishThere = 0f;
        fishingCountdown = 3f;
        buttonPressCountdown = 1f;
        fishing = false;
    }

    void NextFisherSpot(int x)
    {
        fisherSpotsIndex = fisherSpotsIndex + x;
        if(fisherSpotsIndex == FisherSpots.spots.Length)
        {
            fisherSpotsIndex -= 1;
        }
        if (fisherSpotsIndex == -1)
        {
            fisherSpotsIndex += 1;
        }
        fisherSpots = FisherSpots.spots[fisherSpotsIndex];
    }
}