using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsectSpawner : MonoBehaviour
{
    [SerializeField] private Transform insect;

    private Transform[] insects = new Transform[10];
    private Transform player;
    private Vector2 insectPos = Vector2.up * 10;

    private int insectCounter;
    private float distance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < insects.Length; i++)
        {
            insects[i] = Instantiate(insect, insectPos, Quaternion.identity);
            insects[i].SetParent(transform);
        }
    }

    public void SetInsectPosition()
    {
        distance = Random.Range(15, 25);
        insects[insectCounter].position = new Vector2(0, player.position.y - distance);
        insects[insectCounter].gameObject.SetActive(true);
        insectCounter++;

        if (insectCounter >= insects.Length)
        {
            insectCounter = 0;
        }

        StartCoroutine(Repeat());
    }

    IEnumerator Repeat()
    {
        yield return new WaitForSeconds(10);
        SetInsectPosition();
    }
}
