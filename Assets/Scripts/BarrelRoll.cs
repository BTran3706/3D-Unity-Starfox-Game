using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRoll : MonoBehaviour
{
    public float barrelRollDuration = 0.5f;
    public bool rolling = false;

    void Update()
    {
        if (!rolling)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (Input.GetAxis("Horizontal") > 0)
                {
                    StartCoroutine(BarrelRolls(false));
                }
                else
                {
                    StartCoroutine(BarrelRolls(true));
                }
            }
        }
    }

    IEnumerator BarrelRolls(bool direction)
    {
        rolling = true;
        float time = 0.0f;
        int invert = 1;

        if (direction == false)
        {
            invert = -1;
        }

        Vector3 initialRotation = transform.localRotation.eulerAngles;
        Vector3 goalRotation = initialRotation;
        goalRotation.z += 360.0f * invert;

        Vector3 currentRotation = initialRotation;

        while (time < barrelRollDuration)
        {
            currentRotation.z = Mathf.Lerp(initialRotation.z, goalRotation.z, time / barrelRollDuration);
            transform.localRotation = Quaternion.Euler(currentRotation);
            time += Time.deltaTime;
            yield return null;
        }

        rolling = false;
    }

}