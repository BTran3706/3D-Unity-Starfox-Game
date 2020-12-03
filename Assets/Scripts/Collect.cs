using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Collect : MonoBehaviour
{

    public void OnTriggerEnter(Collider collision)
    {
        GameObject otherGO = collision.gameObject;

        if (otherGO.tag == "Player")
        {
            GameManager.Instance.AddScore(5);
            Destroy(gameObject);
        }
    }

}
