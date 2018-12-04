using UnityEngine;
using UnityEngine.SceneManagement;

public class YouWon : MonoBehaviour {

    private float transitionCountdown;
    private bool ending = false;

    public GameObject letter;
    public GameObject nextLevel;
    public GameObject endingButton;
    public GameObject youWonPanel;

    private int current;

    void OnEnable()
    {
        transitionCountdown = 60f;
        current = MainMenu.sceneIndex;
        current++;
        if (current >= SceneManager.sceneCountInBuildSettings)
        {
            AudioManager.instance.Stop("Gameplay");
            AudioManager.instance.Stop("Fishing");
            AudioManager.instance.Play("HappyEnding");
            transitionCountdown = 2f;
            nextLevel.SetActive(!nextLevel.activeSelf);
            endingButton.SetActive(!endingButton.activeSelf);
        }
    }

    void Update()
    {
        if (ending == true)
        {
            if (Input.GetButtonDown("Fishing") || Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                EndEnding();
            }
            return;
        }
        transitionCountdown -= Time.deltaTime;
        if (transitionCountdown <= 0)
        {
            NextLevel();
        }
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        EnemySpawner.allSpawned = false;
        MainMenu.sceneIndex++;
        if (MainMenu.sceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            MainMenu.sceneIndex = 0;
        }
        AudioManager.instance.Stop("Fishing");
        SceneManager.LoadScene(MainMenu.sceneIndex);
    }

    public void EndEnding()
    {
        letter.SetActive(false);
        ending = false;
        nextLevel.SetActive(!nextLevel.activeSelf);
        endingButton.SetActive(!endingButton.activeSelf);
        youWonPanel.SetActive(!youWonPanel.activeSelf);
        AudioManager.instance.Stop("HappyEnding");
        NextLevel();
    }

    public void Ending()
    {
        ending = true;
        youWonPanel.SetActive(!youWonPanel.activeSelf);
        letter.SetActive(true);
    }
}
