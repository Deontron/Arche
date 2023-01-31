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
                collision.gameObject.GetComponent<PlayerScript>().enabled = false;

                StartCoroutine(BackToNormal(collision.gameObject));
            }
            else
            {
                collision.transform.GetComponent<PlayerScript>().DeactivateShield();
            }
        }
    }

    IEnumerator BackToNormal(GameObject player)
    {
        yield return new WaitForSeconds(3);
        player.GetComponent<PlayerScript>().enabled = true;
    }
}
