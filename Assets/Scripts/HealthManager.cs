using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    private static HealthManager instance = null;
    float maxHealth = 100.0f;
    float currentHealth;
    AudioSource sound;
    Gameover gameover;

    public static HealthManager Instance
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
        currentHealth = maxHealth;
        gameover = FindObjectOfType<Gameover>();
    }

    public void ChangeHealth(float amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else if (currentHealth <= 0)
        {
            currentHealth = 0;
            sound.Play();
            gameover.Dead();           
        }
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

}
