using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private float screenWidth, screenHeight;

    GameManager gameManager;

    //float health = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        float coinX = Random.Range(-screenWidth, screenWidth);

        transform.position = new Vector3(coinX, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            

            gameObject.SetActive(false);
            
        }
    }

    public void ActiveCoin()
    {
        gameObject.SetActive(true);
    }
}
