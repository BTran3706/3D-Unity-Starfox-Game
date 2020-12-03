using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody bullet;        
    public float velocity = 10.0f;  
    float destroyTime = 3.0f;    

    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetKeyDown("space"))
        {
            Rigidbody newBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
            newBullet.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
            Destroy(newBullet.gameObject, destroyTime);
        }
    }

}
