using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffectManager : MonoBehaviour
{

    public GameObject ChargingEffect;

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
}
