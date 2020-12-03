using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour 
{

    public static Music instance;

    void Start () 
    {
        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
    }

}
