// Smooth towards the target

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class cameraSmooth : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.5F;
    public int offsetX = 2;
    private Vector3 velocity = Vector3.zero;
    public bool left = true;
    bool oneHit = true;
    float timeStart = 0.3f;
    bool waitTime = true;
    private Vector3 targetPosition;
    void Update()
    {
        // Define a target position above and behind the target transform
        if (left && oneHit)
        {
            offsetX = 2;
            smoothTime = 0.5f;
            timeStart = Time.time;
            print("left");
            waitTime = true;
            oneHit = false;
        }
        else if (!left && !oneHit)
        {
            smoothTime = 0.5f;
            timeStart = Time.time;
            print("right");
            waitTime = true;
            oneHit = true;
        }
        if (Time.time - timeStart > smoothTime && waitTime)
        {
            smoothTime = 0.1f;
            print("change");
            waitTime = false;
        }
        targetPosition = target.TransformPoint(new Vector3(offsetX, .8f, Mathf.Clamp(target.transform.position.z, -10, -15)));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    
        // Smoothly move the camera towards that target position
    }
}
