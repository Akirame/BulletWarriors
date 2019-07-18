using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public enum POWER_TYPE {DAMAGE, HEALTH, AMMO, LAST }
    public POWER_TYPE type;
    public float disappearTime = 10;
    private float timer = 0;

    /// <summary>
    ///  REVEER CUANDO SE HAGA POOL
    /// </summary>
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > disappearTime)
        {
            timer = 0;
            Destroy(this.gameObject);
        }
    }
}
