using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [HideInInspector] public float smoothSpeed = 0.125f;
    
    
    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        // desiredPosition.x = Mathf.Clamp(desiredPosition.x, -1f, 1f);
        desiredPosition.x /= 2f;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;
        // transform.LookAt(target);
    }
}
