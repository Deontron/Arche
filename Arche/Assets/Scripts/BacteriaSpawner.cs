using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
    private float distance;

    [SerializeField] GameObject bacteriaPrefab;

    private float screenHeight, screenWidth;

    List<GameObject> bacteriaList = new();

    Vector2 bacteriaPos = new(0, -20);


    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        GenerateBacteria();

    }

    // Update is called once per frame
    void Update()
    {

        if (bacteriaList[bacteriaList.Count - 1].transform.position.y > Camera.main.transform.position.y - screenHeight + 1f)
        {
            PlaceBacteria();
        }

    }
    void GenerateBacteria()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log(bacteriaPos.x);
            GameObject prefab = Instantiate(bacteriaPrefab, bacteriaPos, Quaternion.identity);
            bacteriaList.Add(prefab);

            NextBacteriaPos();
        }
    }

    void PlaceBacteria()
    {

        for (int i = 0; i < 5; i++)
        {

            GameObject temp;
            temp = bacteriaList[i + 5];
            bacteriaList[i + 5] = bacteriaList[i];
            bacteriaList[i] = temp;
            bacteriaList[i + 5].transform.position = bacteriaPos;

            NextBacteriaPos();
        }
    }

    void NextBacteriaPos()
    {
        distance = Random.Range(10, 20);
        bacteriaPos.y -= distance;

    }
}
