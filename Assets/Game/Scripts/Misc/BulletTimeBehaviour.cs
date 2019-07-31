using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeBehaviour : MonoBehaviour
{
    public float energyBar = 100f;
    public float maxEnergy = 100f;
    public float consumptionFactor = 10f;
    private float timeScale;
    private float fixedDeltaTime;
    private bool consumed = false;
    private bool activated = false;

    private void Start()
    {
        timeScale = Time.timeScale;
        fixedDeltaTime = Time.fixedDeltaTime;
    }
    private void Update()
    {
#if !UNITY_ANDROID
        if (Input.GetMouseButtonDown(1))
        {
            SetConsumeEnabled(true);
        }
#endif

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
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = fixedDeltaTime;
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
