using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseManager : MonoBehaviour
{
    [SerializeField] private InsectSpawner insectSpawner;
    [SerializeField] private Sprite phaseTwoSprite;
    [SerializeField] private Sprite phaseThreeSprite;
    [SerializeField] private Image healthBar;

    private float phaseTwoTime = 10;
    private float phaseThreeTime = 20;
    private GameObject player;

    public GameObject shieldSpawner;
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(PhaseTwoTimer());
        StartCoroutine(PhaseThreeTimer());
    }

    IEnumerator PhaseTwoTimer()
    {
        yield return new WaitForSeconds(phaseTwoTime);
        StartPhaseTwo();
    }

    private void StartPhaseTwo()
    {
        shieldSpawner.SetActive(true);
        insectSpawner.SetInsectPosition();
        healthBar.sprite = phaseTwoSprite;
        healthBar.gameObject.GetComponent<RectTransform>().localScale *= 1.3f;
    }

    IEnumerator PhaseThreeTimer()
    {
        yield return new WaitForSeconds(phaseThreeTime);
        StartPhaseThree();
    }

    private void StartPhaseThree()
    {
        insectSpawner.SetInsectPosition();
        healthBar.sprite = phaseThreeSprite;
        healthBar.gameObject.GetComponent<RectTransform>().localScale *= 1.3f;
    }
}
