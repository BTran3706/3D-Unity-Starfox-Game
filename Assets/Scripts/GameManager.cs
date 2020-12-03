using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public Text scoreText;     
    public int score;

    string highScoreKey = "Highscore value";   
    AudioSource sound;

    public static GameManager Instance
    {
        get 
        { 
            return instance;
        }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }

    void Start()
    {
        sound = GetComponent<AudioSource>();
        score = 0;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int points)
    {
        sound.Play();
        score += points;
        UpdateScore();
    }

    public void UpdateHighscore()
    {
        if (PlayerPrefs.GetInt(highScoreKey) < score)
        {
            PlayerPrefs.SetInt(highScoreKey, score);
        }
    }

}
