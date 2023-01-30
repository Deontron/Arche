using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] rootParts;
    [SerializeField] private float speed;

    void Start()
    {

    }

    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, -speed);
    }
}
