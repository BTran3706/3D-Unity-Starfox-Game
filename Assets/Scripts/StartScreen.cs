using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    AudioSource sound;
    string sceneName;   
    string highScoreKey = "Highscore value";   

    void Start()
    {
        if (!PlayerPrefs.HasKey(highScoreKey))
        {
            PlayerPrefs.SetInt(highScoreKey, 0);
        }

        sound = GetComponent<AudioSource>();
    }

    public void ChangeSceneWithName(string sceneName)
    {
        this.sceneName = sceneName;
        sound.Play();
        Invoke("PlaySound", 1.0f);
    }

    void PlaySound()
    {
        if (sceneName.Equals("LevelScene"))
        {
            Destroy(FindObjectOfType<Music>().gameObject);
        }

        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt(highScoreKey, 0);
        Application.Quit();
    }

}