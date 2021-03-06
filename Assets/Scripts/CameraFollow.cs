﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{    
    public Transform target;

    public float smoothTime = 0.125f;
    public Vector3 offsetPosition;
    public Vector3 offsetTarget;

    [Header("Stopping distance")]
    public float closeStop = 0;
    public float farStop = 0;

    private Vector3 desPos;
    private Vector3 smoothPos;
    private Vector3 velocity = Vector3.zero;

    void Awake()
    {
        transform.position = target.position + offsetPosition + new Vector3(0f, 0f, -2f);
    }

    void LateUpdate ()
    {
        desPos = target.position + offsetPosition;
        smoothPos = Vector3.SmoothDamp(transform.position, desPos, ref velocity, smoothTime);
        smoothPos.z = Mathf.Clamp(smoothPos.z, closeStop, farStop);
        transform.position = smoothPos;


        transform.LookAt(target.position + offsetTarget);
    }
}
