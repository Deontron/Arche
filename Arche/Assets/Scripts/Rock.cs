using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            if (!collision.transform.GetComponent<PlayerScript>().isShieldActive)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<BoxCollider2D>().enabled = false;
                collision.gameObject.GetComponent<PlayerScript>().enabled = false;

                StartCoroutine(BackToNormal(collision.gameObject));
            }
            else
            {
                collision.transform.GetComponent<PlayerScript>().DeactivateShield();
            }
            if (collision.transform.CompareTag("Obstacle"))
            {
                collision.transform.position = new Vector3((Random.Range(0,1f) < 0.5f) ? -Random.Range(1f, 2f) : Random.Range(1f, 2f),collision.transform.position.y,collision.transform.position.z);
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

    }

    public void GetActive()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
