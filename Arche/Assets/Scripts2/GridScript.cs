using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    [SerializeField] private Transform[] tiles;
    [SerializeField] private float timer;

    private int tileCounter = 0;

    private void Start()
    {
        StartCoroutine(Wait());
    }

    IEnumerator SetTile()
    {
        tiles[tileCounter].position = new Vector2(0, tiles[tileCounter].position.y - 85);
        tileCounter++;

        if (tileCounter >= tiles.Length)
        {
            tileCounter = 0;
        }
        yield return new WaitForSeconds(timer);
        StartCoroutine(SetTile());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(timer);
        StartCoroutine(SetTile());
    }
}
