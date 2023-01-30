using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapScript : MonoBehaviour
{
    private Transform player;
    private float distance = 27;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Math.Abs(player.position.y) - Math.Abs(transform.position.y) > distance)
        {
            transform.position = new Vector2(0, transform.position.y - 68);
        }
    }
}
