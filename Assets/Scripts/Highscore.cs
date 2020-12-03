using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{

    public Text highscore;
    string highScoreKey = "Highscore value";

    void Start()
    {
        if (PlayerPrefs.HasKey(highScoreKey))
        {
            highscore.text = PlayerPrefs.GetInt(highScoreKey).ToString();
        }
    }

}