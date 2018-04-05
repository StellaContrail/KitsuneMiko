using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectManager : MonoBehaviour
{

    public GameObject ChargingEffect;
    public GameObject DeathEffect;
    public GameObject WalkingEffect;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowPlayerEffect(string effectName)
    {
        switch (effectName)
        {
            case "Charging":
                ShowChargingEffect();
                break;
            case "Death":
                ShowDeathEffect();
                break;
            case "Walking":
                ShowWalkingEffect();
                break;
        }
    }

    public void HidePlayerEffect(string effectName)
    {
        switch (effectName)
        {
            case "Charging":
                HideChargingEffect();
                break;
        }
    }

    void ShowChargingEffect()
    {
        ChargingEffect.SetActive(true);
    }

    void HideChargingEffect()
    {
        ChargingEffect.SetActive(false);
    }

    void ShowDeathEffect()
    {
        Instantiate(DeathEffect, transform.position + Vector3.up * 0.7f, Quaternion.identity);
    }

    void ShowWalkingEffect()
    {
        Instantiate(WalkingEffect, transform.position, Quaternion.identity);
    }
}
