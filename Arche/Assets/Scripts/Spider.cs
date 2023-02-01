using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private float webDamage;
    [SerializeField] private float spiderHealth;
    [SerializeField] private float shootRate;

    [SerializeField] GameObject bullet;
    
    private GameObject player;

    private float screenHeight, screenWidth;
    Quaternion rotation;

    float timer = 0;
    float distance = 0;

    void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        distance = player.transform.position.y - transform.position.y;
        
        if (Mathf.Abs(distance) < screenHeight)
        {
            //Shoot();

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
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

    }

    void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    
}
