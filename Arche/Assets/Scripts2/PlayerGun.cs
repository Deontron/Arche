using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform bullet;
    [SerializeField] private Transform crossHair;
    [SerializeField] private GameObject[] fullBullets;

    private Vector3 mousePos;
    private int magazine = 3;
    private int bulletAmount = 3;
    private bool isCounting;

    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        crossHair.position = Input.mousePosition;
        Cursor.visible = false;

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
        fullBullets[bulletAmount - 1].SetActive(false);
        bulletAmount--;
    }

    IEnumerator BulletTimer()
    {
        isCounting = true;
        yield return new WaitForSeconds(6);
        fullBullets[bulletAmount].SetActive(true);
        bulletAmount++;
        isCounting = false;
    }
}
