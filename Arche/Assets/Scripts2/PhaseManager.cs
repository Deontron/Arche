using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoBehaviour
{
    private float phaseTwoTime = 100;
    private float timer;
    private GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(PhaseTwoTimer());
    }

    void Update()
    {

    }

    IEnumerator PhaseTwoTimer()
    {
        yield return new WaitForSeconds(phaseTwoTime);
        StartPhaseTwo();
    }

    private void StartPhaseTwo()
    {

    }
}
