using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public static int sceneIndex = 1;

    public GameObject buttons;
    public GameObject howToPlay;
    public GameObject credits;
    public GameObject story;

    private bool sawStory = false;
    private float countdown;

    void Start()
    {
        AudioManager.instance.Play("MainMenu");
    }

    void Update()
    {
        if (sawStory == true)
        {
            countdown -= Time.deltaTime;
            if(countdown <= 0 && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
            {
                Play();
                sawStory = false;
            }
        }
    }

    public void Play()
    {
        if (sceneIndex == 0)
        {
            sceneIndex = 1;
        }
        AudioManager.instance.Stop("MainMenu");
        SceneManager.LoadScene(sceneIndex);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void HowToPlay()
    {
        buttons.SetActive(!buttons.activeSelf);
        howToPlay.SetActive(!buttons.activeSelf);
        credits.SetActive(!credits.activeSelf);
    }

    public void Story()
    {
        buttons.SetActive(!buttons.activeSelf);
        story.SetActive(!story.activeSelf);
        credits.SetActive(!credits.activeSelf);
        sawStory = true;
        countdown = 3f;
    }
}
