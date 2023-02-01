using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
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

    [SerializeField] GameObject healthBarOneCanvas;
    [SerializeField] GameObject healthBarTwoCanvas;
    [SerializeField] GameObject healthBarThreeCanvas;

    [SerializeField] GameObject magazine;

    [SerializeField] private PlayerGun gun;

    private int phase = 1;
    private float phaseTwoTime = 90;
    private float phaseThreeTime = 180;
    private GameObject player;

    [SerializeField] private Slider slider;

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

    private void Update()
    {
        PhaseSlider();
    }

    private void PhaseSlider()
    {
        slider.value += Time.deltaTime;

        if (slider.value >= phaseTwoTime)
        {
            if (phase == 2)
            {
                slider.gameObject.SetActive(false);
            }

            slider.value = 0;
            phase = 2;
        }
    }

    IEnumerator PhaseTwoTimer()
    {
        yield return new WaitForSeconds(phaseTwoTime);
        StartPhaseTwo();
    }

    private void StartPhaseTwo()
    {
        healthBarOneCanvas.SetActive(false);
        healthBarTwoCanvas.SetActive(true);

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
        healthBarTwoCanvas.SetActive(false);
        healthBarThreeCanvas.SetActive(true);

        magazine.SetActive(true);

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
