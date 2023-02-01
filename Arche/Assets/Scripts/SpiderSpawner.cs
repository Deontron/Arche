using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{
    [SerializeField] private Transform spiderPrefab;
    
    private Transform[] spiders = new Transform[10];
    private Transform player;
    private Vector2 spiderPos;

    private int spiderCount;
    private float distance;

    //private float screenHeight, screenWidth;

    void Start()
    {
        //screenHeight = Camera.main.orthographicSize;
        //screenWidth = screenHeight * Camera.main.aspect;

        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < spiders.Length; i++)
        {
            spiders[i] = Instantiate(spiderPrefab, spiderPos, Quaternion.identity);
            spiders[i].SetParent(transform);
        }

    }

    public void SetSpiderPosition()
    {
        distance = Random.Range(15, 25);
        spiders[spiderCount].position = new Vector2(0, player.position.y - distance);
        spiderCount++;

        if (spiderCount >= spiders.Length)
        {
            spiderCount = 0;
        }

        //StartCoroutine(Repeat());
    }

    //IEnumerator Repeat()
    //{
    //    yield return new WaitForSeconds(10f);
    //    SetSpiderPosition();
    //}
}
