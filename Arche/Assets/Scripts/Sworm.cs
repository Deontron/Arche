using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sworm : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool move;
    [SerializeField] private float damage;

    private float max, min;

    private float screenWidth, screenHeight;
    private float swormWidth;

    private float swormPosX = 0f;
    BoxCollider2D boxCollider2D;

    GameManager gm;

    public bool Move
    {
        get { return move; }
        set { move = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>().GetComponent<GameManager>();

        boxCollider2D= GetComponent<BoxCollider2D>();
        swormWidth = boxCollider2D.bounds.size.x / 2;

        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;
        
        swormPosX = Random.Range(-screenWidth + swormWidth, screenWidth - swormWidth);

        if(swormPosX < 0f)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        transform.position = new Vector3(swormPosX, transform.position.y, transform.position.z);
        speed = Random.Range(3f, 5f);

        if (transform.position.x >= 0)
        {
            min = swormWidth;
            max = screenWidth - swormWidth;
        }
        else
        {
            min = -screenWidth + swormWidth;
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

            // Solucanin hareket yonune gore vucut yonu degistirilir.
            if (max - pingPongX <= 0.05f)
            {
                
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            if (pingPongX - 0.05f <= min)
            {
                transform.rotation = Quaternion.Euler(0, transform.rotation.y + 180, 0);
            }
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gm.GetDamage(damage);
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// Sworm objesini aktif hale getirir.
    /// </summary>
    public void GetActive()
    {
        gameObject.SetActive(true);
    }
}
