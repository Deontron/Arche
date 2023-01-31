using UnityEngine;

public class Bacteria : MonoBehaviour
{
    float angle = 0;

    GameManager gm;

    [SerializeField] private float speed;
    [SerializeField] private float height;
    [SerializeField] private float width;

    private float screenWidth, screenHeight;

    float minusThing;
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        speed = Random.Range(1f, 3f);

        minusThing = Random.Range(0, 1f);

        if (minusThing < 0.5f)
        {
            speed *= -1;
        }
        else
        {
            speed *= +1;
        }
        float bacteriaX = Random.Range(-2f, screenWidth / 2);
        transform.position = new Vector3(bacteriaX, transform.position.y, transform.position.z);
    }

    void FixedUpdate()
    {

        x = Mathf.Cos(angle) * width;
        y = Mathf.Sin(angle) * height;

        transform.position += new Vector3(x, y, 0);

        angle += Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!collision.GetComponent<PlayerScript>().isShieldActive)
            {
                gm.GetSick();
            }
            else
            {
                collision.GetComponent<PlayerScript>().DeactivateShield();
            }
        }
    }
    public void GetActive()
    {
        gameObject.SetActive(true);
    }
}
