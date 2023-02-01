using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhaseManager : MonoBehaviour
{
    [SerializeField] private InsectSpawner insectSpawner;
    [SerializeField] private SpiderSpawner spiderSpawner;
    [SerializeField] private Sprite phaseTwoSprite;
    [SerializeField] private Sprite phaseThreeSprite;
    [SerializeField] private Image healthBar;
    [SerializeField] Sprite gunnerSprite;
    [SerializeField] Sprite gunnerShieldSprite;
    [SerializeField] Sprite shieldSprite;
    [SerializeField] Sprite defaultSprite;

    [SerializeField] private PlayerGun gun;

    private float phaseTwoTime = 10;
    private float phaseThreeTime = 20;
    private GameObject player;

    [Header("Spawner")]
    [SerializeField] private ShieldSpawner shieldSpawner;
    [SerializeField] private SwormSpawner swormSpawner;
    [SerializeField] private BacteriaSpawner bacteriaSpawner;
    [SerializeField] private RockSpawner rockSpawner;
    void Start()
    {
        shieldSpawner.SetActive(false);

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
        print("phase 2");
        insectSpawner.SetInsectPosition();
        swormSpawner.SetDistanceForPhase(2f);
        bacteriaSpawner.SetDistanceForPhase(2f);
        rockSpawner.SetDistanceForPhase(2f);
        shieldSpawner.SetActive(true);

        healthBar.sprite = phaseTwoSprite;
        healthBar.gameObject.GetComponent<RectTransform>().localScale *= 1.3f;
        player.GetComponent<PlayerScript>().defaultSprite = defaultSprite;
        player.GetComponent<PlayerScript>().shieldSprite = shieldSprite;
    }

    IEnumerator PhaseThreeTimer()
    {
        yield return new WaitForSeconds(phaseThreeTime);
        StartPhaseThree();
    }

    private void StartPhaseThree()
    {
        print("phase 3");
        spiderSpawner.SetSpiderPosition();
        swormSpawner.SetDistanceForPhase(2.5f);
        bacteriaSpawner.SetDistanceForPhase(2.5f);
        rockSpawner.SetDistanceForPhase(2.5f);

        healthBar.sprite = phaseThreeSprite;
        healthBar.gameObject.GetComponent<RectTransform>().localScale *= 1.3f;
        gun.GetComponent<PlayerGun>().enabled = true;
        player.GetComponent<SpriteRenderer>().sprite = gunnerSprite;
        player.GetComponent<PlayerScript>().defaultSprite = gunnerSprite;
        player.GetComponent<PlayerScript>().shieldSprite = gunnerShieldSprite;
    }
}
