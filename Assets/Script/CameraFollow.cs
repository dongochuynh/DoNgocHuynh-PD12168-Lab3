﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;         // Player để camera bám theo
    public float smoothSpeed = 0.125f;
    public Vector3 offset;           // Khoảng cách giữa camera và player

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
