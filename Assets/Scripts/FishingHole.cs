using UnityEngine;

public class FishingHole : MonoBehaviour {
    
    [Header("Unity Setup")]
    public Material deepSea;
    public GameObject fishSplash;
    public Vector3 fishSplashLocation;

    public static float fishThere;
    public static bool fisherThere = false;
    private float fishCountdown;
    private bool active = true;

    private Renderer rend;
    private Material startColor;
    private Collider col;
    private MeshRenderer mesh;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material;
        fishCountdown = Random.Range(7.5f, 15f);
        fishThere = Random.Range(2.5f, 5f);
        col = GetComponent<Collider>();
        mesh = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (Fisher.fishing == true) {
            return;
        }
        if (active == true && FishingHoleManager.fishSpawned == false)
        {
            SpawnFish();
        }
        else if (active == false && FishingHoleManager.fishSpawned == true)
        {
            ResetFish();
        }
    }

    void SpawnFish()
    {
        fishCountdown -= Time.deltaTime;
        if (fishCountdown < 0)
        {
            FishingHoleManager.fishSpawned = true;
            rend.material = deepSea;
            mesh.enabled = true;
            GameObject effectIns = (GameObject)Instantiate(fishSplash, transform.position + fishSplashLocation, transform.rotation);
            Destroy(effectIns, 2.5f);
            col.enabled = true;
            active = false;
        }
    }

    public void ResetFish()
    {
        fishThere -= Time.deltaTime;
        if (fishThere < 0)
        {
            FishingHoleManager.fishSpawned = false;
            rend.material = startColor;
            col.enabled = false;
            active = true;
            fishCountdown = Random.Range(7.5f, 15f);
            fishThere = Random.Range(2.5f, 5f);
            fisherThere = false;
            mesh.enabled = false;
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        fisherThere = true;
    }

    private void OnTriggerExit(Collider other)
    {
        fisherThere = false;
    }
}
