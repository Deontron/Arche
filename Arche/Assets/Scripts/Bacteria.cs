using UnityEngine;

public class Bacteria : MonoBehaviour
{
    float timeCounter = 0;

    [SerializeField] private float speed;
    [SerializeField] private float height;
    [SerializeField] private float width;

    private float screenWidth, screenHeight;

    float minusThing;
    float x, y;
    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;

        speed = Random.Range(3f, 5f);

        minusThing = Random.Range(0, 1f);

        if(minusThing < 0.5f)
        {
            speed *= -1;
        }
        else
        {
            speed *= +1;
        }
        float bacteriaX = Random.Range(-2f, screenWidth - 1);
        transform.position= new Vector3(bacteriaX, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        
        x = Mathf.Cos(timeCounter) * width;
        y = Mathf.Sin(timeCounter) * height;
        
        transform.position += new Vector3(x, y, 0);
    }

}
