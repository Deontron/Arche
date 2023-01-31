using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    private float distance;

    [SerializeField] GameObject rockPrefab;

    private float screenHeight, screenWidth;

    List<GameObject> rockList = new();

    Vector2 rockPos = new(0, - 30);


    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;
        
        GenerateRock();

    }

    // Update is called once per frame
    void Update()
    {

        if (rockList[rockList.Count - 1].transform.position.y > Camera.main.transform.position.y - screenHeight - 1f)
        {
            PlaceRock();
        }

    }
    void GenerateRock()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject prefab = Instantiate(rockPrefab, rockPos, Quaternion.identity);
            rockList.Add(prefab);

            NextRockPos();
        }
    }

    void PlaceRock()
    {

        for (int i = 0; i < 5; i++)
        {
            rockList[i].GetComponent<Rock>().GetActive();

            GameObject temp;
            temp = rockList[i + 5];
            rockList[i + 5] = rockList[i];
            rockList[i] = temp;
            rockList[i + 5].transform.position = rockPos;

            NextRockPos();
        }
    }

    void NextRockPos()
    {
        distance = Random.Range(10, 20);
        rockPos.y -= distance;
        float posX = Random.Range(-screenWidth + 3, screenWidth - 3);
        rockPos.x = posX;

    }
}
