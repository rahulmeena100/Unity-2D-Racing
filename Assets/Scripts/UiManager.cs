using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public Text scoreText;
    bool gameOver;
    int score;

    public Button[] menuButtons;
    public Button[] pauseButtons;

	public AudioManager am;

	// Use this for initialization
	void Start () {
        gameOver = false;
        score = 0;
        InvokeRepeating("ScoreUpdate", 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
       // try {
            scoreText.text = "Score: " + score;
      //  }
      //  catch
       
	}

    void ScoreUpdate()
    {
        if (gameOver == false)
        {
            score += 1;
        }
    }

    public void GameOver()
    {
        gameOver = true;
        foreach (Button button in menuButtons)
        {
            
                button.gameObject.SetActive(true);
            
        }

        foreach (Button button in pauseButtons)
        {

            button.gameObject.SetActive(false);

        }

    }
    public void Replay()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void Menu()
    {
        Application.LoadLevel("menuScene");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play() {
        Application.LoadLevel("Level1");
    }

    public void Pause() {
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
			am.carSound.Stop();
        }
        else if (Time.timeScale == 0) {
            Time.timeScale = 1;
			am.carSound.Play();
        }

    }

}
