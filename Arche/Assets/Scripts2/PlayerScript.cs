using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] rootParts;
    [SerializeField] private float speed;

    private float rootSpawnRate = 0.2f;
    private int rootId = 0;

    void Start()
    {
        StartCoroutine(RootTimer());
    }

    void FixedUpdate()
    {
        PlayerMovement();

        speed += Time.deltaTime / 25;
    }

    private void SetRoots()
    {
        rootParts[rootId].transform.position = transform.position;

        if (Math.Abs(transform.position.x) <= 8.18f)
        {
            rootParts[rootId].transform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.z * 80));
        }
        else
        {
            rootParts[rootId].transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        rootId++;

        if (rootId >= rootParts.Length)
        {
            rootId = 0;
        }
    }

    private void PlayerMovement()
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, -speed);
        if (Math.Abs(transform.position.x) <= 8.18f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Input.GetAxis("Horizontal") * 70));
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
    }

    IEnumerator RootTimer()
    {
        yield return new WaitForSeconds(rootSpawnRate);
        StartCoroutine(RootTimer());
        SetRoots();
    }
}
