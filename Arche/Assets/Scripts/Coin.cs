using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float screenWidth, screenHeight;

    GameManager gameManager;

    //float health = 0;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        float coinX = Random.Range(-screenWidth + 1, screenWidth - 1);

        transform.position = new Vector3(coinX, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.GetComponent<PlayerScript>().isShieldActive)
            {
                gameManager.IncreaseHealth(50);

                gameObject.SetActive(false);
            }
            else
            {
                collision.GetComponent<PlayerScript>().DeactivateShield();
            }
        }
    }

    public void ActiveCoin()
    {
        gameObject.SetActive(true);
    }
}
