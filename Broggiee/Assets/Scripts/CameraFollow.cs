using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float damping;

    public float minX, maxX, minY, maxY;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 movePosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, damping);

        // Apply boundary limits to the camera's position
        movePosition = new Vector3(
            Mathf.Clamp(movePosition.x, minX, maxX),
            Mathf.Clamp(movePosition.y, minY, maxY),
            movePosition.z
        );

        transform.position = movePosition;
    }
}
