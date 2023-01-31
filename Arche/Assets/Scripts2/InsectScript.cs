using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InsectScript : MonoBehaviour
{
    [SerializeField] private float speed;

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
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        GetComponent<Rigidbody2D>().MovePosition(new Vector2(Mathf.Lerp(transform.position.x, player.transform.position.x, speed), transform.position.y));
    }
}
