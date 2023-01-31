using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<PlayerScript>().enabled = false;

            StartCoroutine(BackToNormal(collision.gameObject));
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
