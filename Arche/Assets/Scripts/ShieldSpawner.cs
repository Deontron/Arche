using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    private float distance;

    [SerializeField] GameObject shieldPrefab;

    private float screenHeight, screenWidth;

    List<GameObject> shieldList = new();

    Vector2 shieldPos = new(0, 0);


    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        shieldPos = new Vector2(Random.Range(-screenWidth + 1f,screenWidth - 1f), Camera.main.transform.position.y - 50f);
        GenerateShield();

    }

    // Update is called once per frame
    void Update()
    {

        if (shieldList[shieldList.Count - 1].transform.position.y > Camera.main.transform.position.y - screenHeight - 1f)
        {
            PlaceShield();
        }

    }
    void GenerateShield()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject prefab = Instantiate(shieldPrefab, shieldPos, Quaternion.identity);
            shieldList.Add(prefab);

            NextShieldPos();
        }
    }

    void PlaceShield()
    {

        for (int i = 0; i < 3; i++)
        {
            shieldList[i].GetComponent<Shield>().GetActive();

            GameObject temp;
            temp = shieldList[i + 5];
            shieldList[i + 5] = shieldList[i];
            shieldList[i] = temp;
            shieldList[i + 5].transform.position = shieldPos;

            NextShieldPos();
        }
    }

    void NextShieldPos()
    {
        distance = Random.Range(35f, 60f);
        shieldPos.y -= distance;
        float posX = Random.Range(-screenWidth, screenWidth);
        shieldPos.x = posX;

    }
}
