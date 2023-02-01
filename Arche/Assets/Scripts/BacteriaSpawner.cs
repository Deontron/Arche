using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
    private float distance;
    [SerializeField] private float Multiplier = 1f;

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
            GameObject prefab = Instantiate(bacteriaPrefab, bacteriaPos, Quaternion.identity);
            bacteriaList.Add(prefab);

            NextBacteriaPos();
        }
    }

    void PlaceBacteria()
    {

        for (int i = 0; i < 5; i++)
        {
            bacteriaList[i].GetComponent<Bacteria>().GetActive();

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
        distance = Random.Range(15 * Multiplier, 25 * Multiplier);
        bacteriaPos.y -= distance;

    }
    public void SetDistanceForPhase(float multiplier)
    {
        Multiplier = multiplier;
    }
}
