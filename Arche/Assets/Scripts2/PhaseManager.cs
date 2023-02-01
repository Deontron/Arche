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

    [SerializeField] private GameObject shieldSpawner;
    [SerializeField] private RockSpawner rockSpawner;
    [SerializeField] private BacteriaSpawner bacteriaSpawner;
    [SerializeField] private SwormSpawner swormSpawner;
    public 
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
        rockSpawner.SetDistanceForPhase(2f);
        bacteriaSpawner.SetDistanceForPhase(2f);
        swormSpawner.SetDistanceForPhase(2f);

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
        rockSpawner.SetDistanceForPhase(2.5f);
        bacteriaSpawner.SetDistanceForPhase(2.5f);
        swormSpawner.SetDistanceForPhase(2.5f);

        insectSpawner.SetInsectPosition();
        healthBar.sprite = phaseThreeSprite;
        healthBar.gameObject.GetComponent<RectTransform>().localScale *= 1.3f;
    }
}
