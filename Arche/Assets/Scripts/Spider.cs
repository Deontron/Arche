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
        screenWidth = screenHeight * Camera.main.aspect;

        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(ShootRate());
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(player.transform.position.y - transform.position.y) < screenHeight)
        {
            FollowPlayer();
            
        }
        
    }

    void FollowPlayer()
    {
        Quaternion rotation = Quaternion.LookRotation(player.transform.position - transform.position, transform.TransformDirection(Vector3.up));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

    }

    //void Shoot()
    //{
    //    Instantiate(bullet, transform.position, transform.rotation);
    //}

    IEnumerator ShootRate()
    {
        //yield return new WaitForSeconds(shootRate);
        while (true)
        {
            if (Mathf.Abs(player.transform.position.y - transform.position.y) < screenHeight)
            {
                yield return new WaitForSeconds(shootRate);
                //Shoot();
            }
            
        }
        
        
    }
}
