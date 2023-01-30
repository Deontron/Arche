using System.Collections;
using UnityEngine;

public class SwormSpawner : MonoBehaviour
{
    [SerializeField] private float distance;

    [SerializeField] GameObject sworm;

    GameObject player;
    Vector2 swormPos = Vector2.zero;

    Vector3 spawnPos= Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        spawnPos.x = player.transform.position.x;
        swormPos.x = spawnPos.x;
    }

    IEnumerator Spawn()
    {
        
        if(sworm != null )
        {
            Instantiate(sworm, swormPos, Quaternion.identity);
            NextSwormPosY();
        }
        yield return new WaitForSeconds(2f);
    }

    void NextSwormPosY()
    {
        swormPos.y -= distance;
    }
}
