using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float playerHealth;
    [SerializeField] private float playerScore;

    private GameObject player;
    private float maxPlayerHealth;
    private float healthDecreaseRate = 7f;
    private float sickDecreaseRate = 20f;

    public GameObject gameOverPanel;

    public TextMeshProUGUI scoreText;
    void Start()
    {
        playerScore = 0;
        gameOverPanel.SetActive(false);

        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerScript>().health;
        maxPlayerHealth = playerHealth;

        scoreText.text = "Score: " + playerScore.ToString();
    }

    void Update()
    {
        DecreaseHealth();

        playerScore = -player.GetComponent<PlayerScript>().transform.position.y;
        scoreText.text = "Score: " + playerScore.ToString();
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

    public void IncreaseHealth(float increaseValue)
    {
        if (playerHealth <= maxPlayerHealth)
        {
            playerHealth += increaseValue;
        }
        else
        {

        }
    }

    public void GetDamage(float damage)
    {
        if (playerHealth > 0)
        {
            playerHealth -= damage;
        }
        else
        {
            Death();
        }
    }

    public void GetSick()
    {
        healthDecreaseRate = sickDecreaseRate;
        player.GetComponent<SpriteRenderer>().color = Color.red;

        StartCoroutine(SickDuration());
    }

    private void Death()
    {
        gameOverPanel.SetActive(true);
        

    }

    IEnumerator SickDuration()
    {
        yield return new WaitForSeconds(5);
        healthDecreaseRate = sickDecreaseRate / 2;
        player.GetComponent<SpriteRenderer>().color = Color.white;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
