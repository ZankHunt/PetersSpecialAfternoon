using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pausemenu;

    void Update()
    {
        if (GameManager.gameEnd == true)
            return;

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public void Pause()
    {
        pausemenu.SetActive(!pausemenu.activeSelf);

        if (pausemenu.activeSelf)
        {
            Time.timeScale = 0f;
        } else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Pause();
        AudioManager.instance.Stop("Fishing");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void RetryGameOver()
    {
        AudioManager.instance.Stop("GameOver");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        AudioManager.instance.Stop("GameOver");
        AudioManager.instance.Stop("Gameplay");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
