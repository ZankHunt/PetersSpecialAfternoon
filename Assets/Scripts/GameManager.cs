using UnityEngine;

public class GameManager : MonoBehaviour {

    public static bool gameEnd;

    public GameObject gameOverUI;
    public GameObject youWonUI;

    public static float transitionTime;

    void Start()
    {
        AudioManager.instance.Play("Gameplay");
        gameEnd = false;
        transitionTime = 5f;
    }

    void Update () {
        if (gameEnd == true)
            return;
		if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
        if (EnemySpawner.allSpawned == true && EnemySpawner.enemiesSpawned <= 0)
        {
            transitionTime -= Time.deltaTime;
            if(transitionTime <= 0)
            {
                Time.timeScale = 0f;
                youWonUI.SetActive(true);
            }
        }
	}

    void EndGame()
    {
        gameEnd = true;
        gameOverUI.SetActive(true);
    }
}
