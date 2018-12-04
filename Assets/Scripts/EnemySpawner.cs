using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [Header("Unity Setup")]
    public float spawnCooldownRemaining = 5f;
    public float spawnCooldown = 0.25f;

    public Transform spawnPoint;

    public static int enemiesSpawned = 0;

    public static bool allSpawned = false;

    [System.Serializable]
    public class Waves
    {
        public GameObject enemyPrefab;
        public int number;
        [System.NonSerialized]
        public int spawned = 0;
    }

    public Waves[] waves;

    void Update()
    {
        spawnCooldownRemaining -= Time.deltaTime;
        if (spawnCooldownRemaining < 0)
        {
            spawnCooldownRemaining = spawnCooldown;

            bool didSpawn = false;

            foreach (Waves wave in waves)
            {
                if (wave.spawned < wave.number)
                {
                    wave.spawned++;
                    Instantiate(wave.enemyPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
                    enemiesSpawned++;

                    didSpawn = true;
                    break;
                }
            }

            if (didSpawn == false)
            {
                if (transform.parent.childCount > 1)
                {
                    transform.parent.GetChild(1).gameObject.SetActive(true);
                }
                else
                {
                    allSpawned = true;
                }
                Destroy(gameObject);
            }
        }
    }
}
