using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Gun {
    private GameObject currentGrenade;
    private void Update() {
        SecondaryShoot();
    }
    public override void Shoot() {
        if(CanShoot()) {
            currentGrenade = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity);
            currentGrenade.GetComponent<GrenadeBehaviour>().SetDirection(shootPoint.transform.forward);
            currentAmmo--;
        }
    }
    public void SecondaryShoot() {
        if(Input.GetKeyDown(KeyCode.Mouse1)) {
            if(currentGrenade)
            currentGrenade.GetComponent<GrenadeBehaviour>().Explode();            
        }
    }
}
