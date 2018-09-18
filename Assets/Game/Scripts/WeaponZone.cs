using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponZone : MonoBehaviour {

    public float timeInZone;
    public float timeToEnable;
    private float timerZone;
    private float timerEnable;
    private bool isEnabled = true;
    public Image sprite;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    void Update () {
        if(isEnabled)
        {
            if(timerZone >= timeInZone)
            {
                isEnabled = false;
                timerZone = 0;
            }
        }
        else
        {
            timerEnable += Time.deltaTime;
            if(timerEnable >= timeToEnable)
            {
                isEnabled = true;
                timerEnable = 0;
            }
        }
        
	}

    private void OnTriggerStay(Collider other) {
        if(isEnabled && other.tag == "Player")
        {
            timerZone += Time.deltaTime;
            sprite.fillAmount = timerZone / timeInZone;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.tag == "Player")
        {
            timerZone = 0;
            sprite.fillAmount = 0;
        }
    }


}
