using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    private float distance;

    [SerializeField] GameObject rockPrefab;

    private float screenHeight, screenWidth;

    List<GameObject> rockList = new();

    Vector2 rockPos = new(0, 0);

    BoxCollider2D boxCollider2D;
    float rockWidth;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        rockPos = new Vector2(Random.Range(-screenWidth + 1f, screenWidth - 1f), -30f);

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

            NextRockPos(0);
        }
    }

    void PlaceRock()
    {

        for (int i = 0; i < 5; i++)
        {
            rockList[i].GetComponent<Rock>().GetActive();
            boxCollider2D = rockList[i].GetComponent<BoxCollider2D>();
            rockWidth = boxCollider2D.bounds.size.x / 2;
            GameObject temp;
            temp = rockList[i + 5];
            rockList[i + 5] = rockList[i];
            rockList[i] = temp;
            rockList[i + 5].transform.position = rockPos;

            NextRockPos(rockWidth);
        }
    }

    void NextRockPos(float width)
    {
        distance = Random.Range(10, 20);
        rockPos.y -= distance;
        
        float posX = Random.Range(-screenWidth + width, screenWidth - width);
        rockPos.x = posX;

    }
}
