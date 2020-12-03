using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float movementSpeed = 15.0f;
    public int inverse = 1;
    public float rotationSpeed = 50.0f;

    float minX = -50;
    float maxX = 25;
    float minY = -10f;
    float maxY = 25;
    
    BarrelRoll roll;
    AudioSource collisionSound;

    void Start()
    {
        collisionSound = GetComponent<AudioSource>();
        roll = FindObjectOfType<BarrelRoll>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, (inverse) * vertical, 0);
        Vector3 finalDirection = new Vector3(horizontal, (inverse) * vertical, 1.0f);

        // transform.position += direction * movementSpeed * Time.deltaTime;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x + direction.x * movementSpeed * Time.deltaTime, minX, maxX), 
                                         Mathf.Clamp(transform.position.y + direction.y * movementSpeed * Time.deltaTime, minY, maxY),
                                         transform.position.z + direction.z * movementSpeed * Time.deltaTime);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDirection), Mathf.Deg2Rad * rotationSpeed);
    }

    public void OnTriggerEnter(Collider collision)
    {
        GameObject otherGO = collision.gameObject;

        if (roll.rolling == false)
        {
            roll.rolling = true;

            if (otherGO.tag == "Enemy")
            {
                collisionSound.Play();
                Destroy(otherGO);
                HealthManager.Instance.ChangeHealth(-10.0f);
            }
            else if (otherGO.tag == "Terrain")
            {
                Debug.Log("Hurt");
                collisionSound.Play();
                HealthManager.Instance.ChangeHealth(-5.0f);
            }

            Invoke("TurnOnCollider", 2.0f);
        }
    }

    void TurnOnCollider()
    {
        roll.rolling = false;
    }

}