using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sworm : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private bool move;
    private float max, min;

    private float width, height;
    private float swormWidth;

    private float swormPosX = 0f;
    BoxCollider2D boxCollider2D;

    

    public bool Move
    {
        get { return move; }
        set { move = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D= GetComponent<BoxCollider2D>();
        swormWidth = boxCollider2D.bounds.size.x / 2;

        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
        
        swormPosX = Random.Range(-width + swormWidth, width - swormWidth);

        transform.position = new Vector3(swormPosX, transform.position.y, transform.position.z);

        move= true;

        if (transform.position.x >= 0)
        {
            min = swormWidth;
            max = width - swormWidth;
        }
        else
        {
            min = -width + swormWidth;
            max = -swormWidth;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            float pingPongX = Mathf.PingPong(speed * Time.time, max - min) + min;
            Vector2 pingPong = new(pingPongX, transform.position.y);
            transform.position = pingPong;
        }
        
    }
}
