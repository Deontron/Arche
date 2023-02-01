using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    [SerializeField] private InsectSpawner insectSpawner;
    [SerializeField] private SpiderSpawner spiderSpawner;

    [SerializeField] private float phaseTwoTime = 100;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(PhaseTwoTimer());
    }

    IEnumerator PhaseTwoTimer()
    {
        yield return new WaitForSeconds(phaseTwoTime);
        StartPhaseTwo();
    }

    private void StartPhaseTwo()
    {
        insectSpawner.SetInsectPosition();
        spiderSpawner.SetSpiderPosition();
    }
}
