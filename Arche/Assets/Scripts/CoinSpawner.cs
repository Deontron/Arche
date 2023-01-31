using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    private float distance;

    [SerializeField] GameObject coinPrefab;

    private float height, width;

    List<GameObject> coinList = new();

    //int id = 0;

    //[SerializeField] private float spawnSec;
    //[SerializeField] private bool randomSpawn;

    Vector2 coinPos = new(0, -10);


    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        GenerateCoin();

        //StartCoroutine(Timer());
        //StartCoroutine(Spawn(spawnSec));
    }

    // Update is called once per frame
    void Update()
    {

        if (coinList[coinList.Count - 1].transform.position.y > Camera.main.transform.position.y - height + 1f)
        {
            PlaceCoin();
        }

    }
    void GenerateCoin()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(coinPos.x);
            GameObject prefab = Instantiate(coinPrefab, coinPos, Quaternion.identity);
            coinList.Add(prefab);

            NextCoinPos();
        }
    }

    void PlaceCoin()
    {

        for (int i = 0; i < 5; i++)
        {

            coinList[i].GetComponent<Coin>().ActiveCoin();

            GameObject temp;
            temp = coinList[i + 5];
            coinList[i + 5] = coinList[i];
            coinList[i] = temp;
            coinList[i + 5].transform.position = coinPos;


            NextCoinPos();
        }
    }

    void NextCoinPos()
    {
        distance = Random.Range(7, 20);
        coinPos.y -= distance;
        float posX = Random.Range(-width + 1, width - 1);
        coinPos.x = posX;
        //RandomPosition();

    }

    //IEnumerator Timer()
    //{
    //    yield return new WaitForSeconds(spawnSec);
    //    StartCoroutine(Timer());

    //    PlaceSworm();
    //}

    //IEnumerator Spawn(float spawnSec)
    //{
    //    GameObject swormm;
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(spawnSec);
    //        if (swormPrefab != null)
    //        {
    //            Debug.Log(swormPos);
    //            swormm = Instantiate(swormPrefab, swormPos, Quaternion.identity);
    //            swormList.Add(swormm);
    //            NextSwormPos();
    //        }
    //    }

    //}



    //private void RandomPosition()
    //{
    //    float random = Random.Range(0, 1f);
    //    if (random < 0.5f)
    //    {
    //        swormPos.x = width / 2;
    //        //Debug.Log("0.5 den kucuk");
    //    }
    //    else
    //    {
    //        swormPos.x = -width / 2;
    //        //Debug.Log("0.5 den buyuk");
    //    }
    //}

    //private bool yon = true;
    //private void CrossPosition()
    //{

    //    if (yon)
    //    {
    //        swormPos.x = width / 2;
    //        yon = false;
    //    }
    //    else
    //    {
    //        swormPos.x = -width / 2;
    //        yon = true;
    //    }
    //}
}
