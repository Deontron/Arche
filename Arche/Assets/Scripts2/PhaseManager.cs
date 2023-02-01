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
        print("phase 2");
        insectSpawner.SetInsectPosition();
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
        healthBar.sprite = phaseThreeSprite;
        healthBar.gameObject.GetComponent<RectTransform>().localScale *= 1.3f;
        gun.GetComponent<PlayerGun>().enabled = true;
        player.GetComponent<SpriteRenderer>().sprite = gunnerSprite;
        player.GetComponent<PlayerScript>().defaultSprite = gunnerSprite;
        player.GetComponent<PlayerScript>().shieldSprite = gunnerShieldSprite;
    }
}
