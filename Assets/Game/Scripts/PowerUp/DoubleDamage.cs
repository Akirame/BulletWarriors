using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDamage : PowerUp {

	// Use this for initialization
	void Start () {
        type = POWER_TYPE.DAMAGE;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            WeaponBehaviour wb = other.gameObject.GetComponent<WeaponBehaviour>();
            wb.DoubleDamage();
            Destroy(this.gameObject);
        }
    }

}
