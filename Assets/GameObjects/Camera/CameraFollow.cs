using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.
    public Vector3 offset;              // The initial offset from the target.

    void Update()
    {
        // Find the Player Tag
        try
        {
            target = GameObject.FindGameObjectWithTag("Player").transform; // this is goint to find a certain tagged object from hirarchey and assing it to target.
        }
        catch (NullReferenceException)
        {
            Debug.Log("target gameObject is not present in hierarchy ");
        }
    }


    void LateUpdate()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 desiredPosition = target.position + offset;
        transform.position = desiredPosition;
    }
}
