using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{
    [SerializeField] private Transform spider;

    private Transform[] spiders = new Transform[10];
    private Transform player;
    private Vector2 spiderPos = Vector2.up * 100;

    private int spiderCounter;
    private float distance;
    private float spiderX;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < spiders.Length; i++)
        {
            spiders[i] = Instantiate(spider, spiderPos, Quaternion.identity);
            spiders[i].SetParent(transform);
        }
    }

    public void SetSpiderPosition()
    {
        distance = Random.Range(15, 22);
        spiderX = Random.Range(-7, 8);
        spiders[spiderCounter].position = new Vector2(spiderX, player.position.y - distance);
        spiders[spiderCounter].gameObject.SetActive(true);
        spiderCounter++;

        if (spiderCounter >= spiders.Length)
        {
            spiderCounter = 0;
        }

        StartCoroutine(RepeatSpider());
    }

    IEnumerator RepeatSpider()
    {
        yield return new WaitForSeconds(8);
        SetSpiderPosition();
    }
}
