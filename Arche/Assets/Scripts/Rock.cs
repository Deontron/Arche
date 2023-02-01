using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Vector2 playerSpeed;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!collision.transform.GetComponent<PlayerScript>().isShieldActive)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                playerSpeed = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
                collision.gameObject.GetComponent<PlayerScript>().enabled = false;

                collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

                StartCoroutine(BackToNormal(collision.gameObject));
            }
            else
            {
                transform.gameObject.SetActive(false);
                collision.transform.GetComponent<PlayerScript>().DeactivateShield();
            }
            if (collision.transform.CompareTag("Obstacle"))
            {
                collision.transform.position = new Vector3((Random.Range(0, 1f) < 0.5f) ? -Random.Range(1f, 2f) : Random.Range(1f, 2f), collision.transform.position.y, collision.transform.position.z);
            }
            if (collision.transform.CompareTag("Collectable"))
            {
                collision.transform.position = new Vector3((Random.Range(0, 1f) < 0.5f) ? -Random.Range(1f, 2f) : Random.Range(1f, 2f), collision.transform.position.y, collision.transform.position.z);
            }
        }
    }

    IEnumerator BackToNormal(GameObject player)
    {
        yield return new WaitForSeconds(3);
        player.GetComponent<PlayerScript>().enabled = true;
        player.GetComponent<Rigidbody2D>().velocity = playerSpeed;


    }

    public void GetActive()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
