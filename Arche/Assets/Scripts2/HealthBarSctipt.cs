using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarSctipt : MonoBehaviour
{
    private PlayerScript ps;
    private float maxPlayerHealth;
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        maxPlayerHealth = ps.health;
    }

    void Update()
    {
        SetHealthBar();
    }

    private void SetHealthBar()
    {
        GetComponent<Image>().fillAmount = (int)ps.health / maxPlayerHealth;

        if (ps.health > 255)
        {
            GetComponent<Image>().color = new Color((maxPlayerHealth - ps.health) / maxPlayerHealth, 255, 0);
        }
        else
        {
            GetComponent<Image>().color = new Color(255, ps.health / maxPlayerHealth, 0);
        }
    }
}
