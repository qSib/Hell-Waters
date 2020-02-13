using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance;
    int score;
    int highScore;

    void Awake()
    {
        if(instance == null) //Makes sure there's only one instance of this script.
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        score = 0;
        highScore = 0;

    }

    void Update()
    {
        if (score > highScore) //If the current score is higher than the highscore, that score is the new highscore.
        {
            highScore = score;
        }
    }

    public int GetScore() //Returns the current score
    {
        return score;
    }

    public int GetHighScore() //Returns the highscore
    {
        return highScore;
    }

    public void AddScore(int value) //Adds a value to the current score
    {
        score += value;
    }

    public void ResetScore()
    {
        score = 0;
    }
}
