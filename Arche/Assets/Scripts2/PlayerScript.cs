using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] rootParts;
    [SerializeField] private float speed;

    private float rootTimer;
    private float rootSpawnRate = 0.3f;
    private int rootId = 0;

    void Start()
    {
        StartCoroutine(RootTimer());
    }

    void Update()
    {
        PlayerMovement();
    }

    private void SetRoots()
    {
        rootParts[rootId].transform.position = transform.position;
        rootParts[rootId].transform.rotation = transform.rotation;

        rootId++;

        if (rootId >= rootParts.Length)
        {
            rootId = 0;
        }
    }

    private void PlayerMovement()
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, -speed);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Input.GetAxis("Horizontal") * 45));
    }

    IEnumerator RootTimer()
    {
        yield return new WaitForSeconds(rootSpawnRate);
        StartCoroutine(RootTimer());
        SetRoots();
    }
}
