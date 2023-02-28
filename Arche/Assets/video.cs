using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class video : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Video());
    }
    IEnumerator Video()
    {
        yield return new WaitForSecondsRealtime(31f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
