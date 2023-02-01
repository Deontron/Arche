using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform bullet;

    private Vector3 mousePos;
    private int magazine = 3;
    private int bulletAmount = 3;
    private bool isCounting;

    void Start()
    {
    }

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Quaternion rotation = Quaternion.LookRotation(mousePos - transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

        if (Input.GetMouseButtonDown(0) && bulletAmount > 0)
        {
            Fire();
        }

        if (bulletAmount < magazine && !isCounting)
        {
            StartCoroutine(BulletTimer());
        }
    }

    private void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
        bulletAmount--;
    }

    IEnumerator BulletTimer()
    {
        isCounting = true;
        yield return new WaitForSeconds(7);
        bulletAmount++;
        isCounting = false;
    }
}
