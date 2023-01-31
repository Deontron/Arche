using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float playerHealth;

    private GameObject player;
    private float maxPlayerHealth;
    private float healthDecreaseRate = 10f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerScript>().health;
        maxPlayerHealth = playerHealth;
    }

    void Update()
    {
        DecreaseHealth();
    }

    private void DecreaseHealth()
    {
        if (playerHealth > 0)
        {
            playerHealth -= (Time.deltaTime * healthDecreaseRate);
            player.GetComponent<PlayerScript>().health = playerHealth;
        }
        else
        {
            Death();
        }
    }

    private void IncreaseHealth()
    {
        if (playerHealth <= maxPlayerHealth)
        {

        }
        else
        {

        }
    }

    private void Death()
    {

    }
}
