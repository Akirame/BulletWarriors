using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTimeBehaviour : MonoBehaviour
{
    public float energyBar = 100f;
    public float consumptionFactor = 1f;
    private bool consumed = false;
    public float maxEnergy = 100f;
    private void Update()
    {
        if (Input.GetKey(KeyCode.F) && energyBar > 0f && !consumed)
        {
            Time.timeScale = 0.3f;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            energyBar -= consumptionFactor * Time.unscaledDeltaTime;
            if (energyBar <= 0)
                consumed = true;
        }
        else
        {
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
}
