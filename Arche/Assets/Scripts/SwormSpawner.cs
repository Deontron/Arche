using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SwormSpawner : MonoBehaviour
{
    private float distance;

    [SerializeField] GameObject swormPrefab;

    //GameObject player;

    private float height, width;

    List<GameObject> swormList = new();
    
    //int id = 0;

    //[SerializeField] private float spawnSec;
    //[SerializeField] private bool randomSpawn;

    Vector2 swormPos = new(0,-5f);
    

    // Start is called before the first frame update
    void Start()
    {
        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;

        //player = GameObject.Find("Player");
        GenerateSworm();
        //StartCoroutine(Timer());
        //StartCoroutine(Spawn(spawnSec));
    }

    // Update is called once per frame
    void Update()
    {

        if (swormList[swormList.Count - 1].transform.position.y > Camera.main.transform.position.y - height + 1f)
        {
            PlaceSworm();
        }
        
    }
    void GenerateSworm()
    {
        for(int i = 0; i < 20; i++)
        {
            GameObject prefab = Instantiate(swormPrefab, swormPos, Quaternion.identity);
            swormList.Add(prefab);
            prefab.GetComponent<Sworm>().Move = true;
            
            NextSwormPos();
        }
    }

    void PlaceSworm()
    {

        for (int i = 0; i < 10; i++)
        {
            GameObject temp;
            temp = swormList[i + 10];
            swormList[i + 10] = swormList[i];
            swormList[i] = temp;
            swormList[i + 10].transform.position = swormPos;
            

            NextSwormPos();
        }
    }

    void NextSwormPos()
    {
        distance = Random.Range(5, 10);
        swormPos.y -= distance;

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
