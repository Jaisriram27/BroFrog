using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    void Start()
    {
        
    }
    void Update()
    {
        transform.position = new Vector3(transform.position.x, target.transform.position.y, -10);
    }
}
