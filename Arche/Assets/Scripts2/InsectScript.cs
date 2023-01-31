using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class InsectScript : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
