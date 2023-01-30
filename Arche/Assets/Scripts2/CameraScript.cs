using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float speed;

    private float velocity = 0;

    void FixedUpdate()
    {
        //transform.position = Vector3.SmoothDamp(transform.position, target.position + offset, ref velocity, speed);

        transform.position = new Vector3(transform.position.x, Mathf.SmoothDamp(transform.position.y, target.position.y, ref velocity, speed), -10);
    }
}