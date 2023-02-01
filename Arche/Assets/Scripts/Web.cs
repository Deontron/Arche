using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float bulletDamage;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletSpeed * Time.deltaTime * -transform.up;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Isabet etti");
            collision.gameObject.GetComponent<PlayerScript>().speed *= 0.7f;
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            gameManager.GetDamage(bulletDamage);
            StartCoroutine(SlowEffect(collision));

        }
    }

    IEnumerator SlowEffect(Collider2D collision)
    {
        yield return new WaitForSeconds(1.5f);
        collision.gameObject.GetComponent<PlayerScript>().speed /= 0.7f;
        collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
