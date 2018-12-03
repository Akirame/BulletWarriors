using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeBehaviour : MonoBehaviour
{
    public float energyBar = 100f;
    public float maxEnergy = 100f;
    public float consumptionFactor = 10f;
    private bool consumed = false;
    private bool activated = false;
    private void Update()
    {
        if (activated && energyBar > 0f && !consumed)
        {
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            energyBar -= consumptionFactor * Time.unscaledDeltaTime;
            if (energyBar <= 0)
                consumed = true;
        }
        else
        {
            activated = false;
            Time.timeScale = 1f;
            if (energyBar < maxEnergy)
            {
                energyBar += consumptionFactor * Time.unscaledDeltaTime * 2;
                if (energyBar >= maxEnergy)
                {
                    energyBar = 100f;
                    consumed = false;
                }
            }
        }
    }

    internal void SetConsumeEnabled(bool pressed)
    {
        activated = pressed;
    }

}
