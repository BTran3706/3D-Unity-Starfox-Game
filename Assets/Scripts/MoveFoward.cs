using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{

    public float speed = 50.0f; 

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

}