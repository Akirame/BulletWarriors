using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedKit : PowerUp {

	// Use this for initialization
	void Start () {
        type = POWER_TYPE.HEALTH;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().RestoreLife(25);
            Destroy(this.gameObject);
        }
    }

}
