using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class GameOver : MonoBehaviour
{
    public SteamVR_Action_Boolean fireAction;
    float fireCountdown = 3f;
    public Text scoreText;
    public Text highScoreText;
    int score;
    int highScore;

    void Start()
    {
        score = ScoreKeeper.instance.GetScore(); //Gets the score from the ScoreKeeper script.
        highScore = ScoreKeeper.instance.GetHighScore();
    }

    void Update()
    {
        scoreText.text = "SCORE: " + score;
        highScoreText.text = "HIGH SCORE: " + highScore;

        fireCountdown -= Time.deltaTime;

        if (fireCountdown <= 0f && fireAction.stateDown) //Restarts the game if the trigger is pressed.
        {
            ScoreKeeper.instance.ResetScore();
            SceneManager.LoadScene("Cage");
        }

        if (fireCountdown <= 0f && Input.GetMouseButtonDown(0))
        {
            ScoreKeeper.instance.ResetScore();
            SceneManager.LoadScene("Cage");
        }
    }
}
