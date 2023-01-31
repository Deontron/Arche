using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private float webDamage;
    [SerializeField] private float spiderHealth;
    [SerializeField] private float shootRate;

    [SerializeField] GameObject bullet;
    
    GameObject player;

    private float screenHeight, screenWidth;
    Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ShootRate());
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        if(transform.position.y >Camera.main.transform.position.y + screenHeight)
        {
            Destroy(gameObject);

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

    IEnumerator ShootRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootRate);
            Shoot();
        }
        
        
    }
}
