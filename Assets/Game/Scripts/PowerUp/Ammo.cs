using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : PowerUp {

	// Use this for initialization
	void Start () {
        type = POWER_TYPE.AMMO;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            WeaponBehaviour wb = other.gameObject.GetComponent<WeaponBehaviour>();
            wb.ResetWeaponsEquipedAmmo();
            Destroy(this.gameObject);
        }
    }

}
