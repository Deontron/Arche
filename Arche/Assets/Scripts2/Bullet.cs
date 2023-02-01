using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        transform.position += -transform.up * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
