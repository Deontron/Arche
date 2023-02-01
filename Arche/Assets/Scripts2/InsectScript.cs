using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InsectScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private GameManager gm;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        InscetMovement();
    }

    private void InscetMovement()
    {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(-Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        GetComponent<Rigidbody2D>().MovePosition(new Vector2(Mathf.Lerp(transform.position.x, player.transform.position.x, speed), transform.position.y));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.GetComponent<PlayerScript>().isShieldActive)
            {
                gm.GetDamage(damage);
                gameObject.SetActive(false);
            }
            else
            {
                collision.GetComponent<PlayerScript>().DeactivateShield();
            }
        }
    }
}
