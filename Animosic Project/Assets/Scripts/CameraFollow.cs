using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = .125f;

    public Vector3 offset;

    public void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, -10);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); 
        transform.position = smoothedPosition;
        //transform.LookAt(target);
    }
}
