using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    public Text gameoverText;      
    public Text completeText;      
    public Text finalScoreText;    
    public string sceneName = "Menu";      
    MoveFoward plane;
    string highScoreKey = "Highscore value";   

    void Start()
    {
        plane = FindObjectOfType<MoveFoward>();
    }

    public void Dead()
    {
        plane.speed = 0;
        gameoverText.enabled = true;
        finalScoreText.text = "SCORE: " + GameManager.Instance.score;
        finalScoreText.enabled = true;

        if (PlayerPrefs.GetInt(highScoreKey) < GameManager.Instance.score)
        {
            PlayerPrefs.SetInt(highScoreKey, GameManager.Instance.score);
        }

        Invoke("LoadMenu", 3.0f);
    }

    public void MissionComplete()
    {
        plane.speed = 0;
        completeText.enabled = true;
        finalScoreText.enabled = true;
        finalScoreText.text = "SCORE: " + GameManager.Instance.score;

        if (PlayerPrefs.GetInt(highScoreKey) < GameManager.Instance.score)
        {
            PlayerPrefs.SetInt(highScoreKey, GameManager.Instance.score);
        }

        Invoke("LoadMenu", 3.0f);
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OnTriggerEnter(Collider collision)
    {
        GameObject otherGO = collision.gameObject;

        if (otherGO.tag == "Player")
        {
            MissionComplete();
        }
    }

}
