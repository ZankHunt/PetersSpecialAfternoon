using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    private float transitionCountdown;

    void OnEnable()
    {
        AudioManager.instance.Stop("Gameplay");
        AudioManager.instance.Stop("Fishing");
        AudioManager.instance.Play("GameOver");
        transitionCountdown = 60f;  
    }

    void Update () {
        transitionCountdown -= Time.deltaTime;
        if(transitionCountdown <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}
}
