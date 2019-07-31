using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour {

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !activated && other.GetComponent<WeaponBehaviour>().firstWeapon)
        {
            activated = true;
            GameManager.GetInstance().gameStarted = true;
        }
    }

}
