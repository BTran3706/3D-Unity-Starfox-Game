using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] spawnObject;    
    public float xRange = 1.0f; 
    public float yRange = 1.0f; 
    public float minSpawnTime = 1.0f;   
    public float maxSpawnTime = 10.0f; 

    void Start()
    {
        Invoke("SpawnObject", Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnObject()
    {
        float xOffset = Random.Range(-xRange, xRange);
        float yOffset = Random.Range(-yRange, yRange);
        int spawnObjectIndex = Random.Range(0, spawnObject.Length);
        Instantiate(spawnObject[spawnObjectIndex], transform.position + new Vector3(xOffset, yOffset, 0), spawnObject[spawnObjectIndex].transform.rotation);
        Invoke("SpawnObject", Random.Range(minSpawnTime, maxSpawnTime));
    }

}
