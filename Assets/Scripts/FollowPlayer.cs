using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPlayer : MonoBehaviour
{
    public Transform objectToFollow;     
    public Vector2 movementRatio; 

    void LateUpdate()
    {
        Vector3 newPosition = objectToFollow.position;
        newPosition.x *= movementRatio.x;
        newPosition.y = (newPosition.y * movementRatio.y) + 5.0f;
        newPosition.z = transform.position.z;
        transform.position = newPosition;
    }

}