using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Sprite defaultSprite;
    public Sprite shieldSprite;
    public float health = 20f;
    public bool isShieldActive = false;

    [SerializeField] private GameObject[] rootParts;
    public float speed;

    private float rootSpawnRate = 0.1f;
    private int rootId = 0;

    private GameManager gm;

    void Start()
    {
        speed = 4;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        StartCoroutine(RootTimer());
    }

    void FixedUpdate()
    {
        PlayerMovement();
        print(Time.timeScale);
        speed += Time.fixedDeltaTime / 50;
    }
    private void Update()
    {
        if (Math.Abs(transform.position.x) <= 8.18f)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, Input.GetAxis("Horizontal") * 70));
        }
        else
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
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
        GetComponent<SpriteRenderer>().sprite = shieldSprite;
    }

    public void DeactivateShield()
    {
        isShieldActive = false;
        GetComponent<SpriteRenderer>().sprite = defaultSprite;
    }

    
}
