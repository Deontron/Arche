using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] Sprite phaseOneSprite;
    [SerializeField] Sprite phaseTwoSprite;
    [SerializeField] Sprite phaseThreeSprite;

    public float health = 510;
    public bool isShieldActive = false;

    [SerializeField] private GameObject[] rootParts;
    public float speed;

    private float rootSpawnRate = 0.1f;
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

    public void ActivateShield()
    {
        isShieldActive = true;
        GetComponent<SpriteRenderer>().sprite = phaseOneSprite;
    }

    public void DeactivateShield()
    {
        isShieldActive = false;
        GetComponent<SpriteRenderer>().sprite = phaseTwoSprite;
    }
}
