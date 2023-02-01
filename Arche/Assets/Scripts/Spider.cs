using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private float webDamage;
    [SerializeField] private float spiderHealth;
    [SerializeField] private float shootRate;

    [SerializeField] GameObject bullet;

    private Transform player;

    Quaternion rotation;

    float timer = 0;
    float distance = 10;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Vector2.Distance(transform.position, player.position) <= distance)
        {
            FollowPlayer();
            if (timer % shootRate < 0.005f)
            {
                Debug.Log("Atessss!");
                Shoot();
            }
        }
    }

    void FollowPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
