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
            
            currentAmmo--;
            muzzleFlash.Play();
            if (muzzleFlash.isPlaying)
            {
                currentGrenade = Instantiate(bullet, shootPoint.transform.position, Quaternion.identity, bulletGroup);
                currentGrenade.GetComponent<GrenadeBehaviour>().SetDirection(shootPoint.transform.forward);
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                currentGrenade.transform.rotation = shootPoint.transform.rotation;
            }
        }
    }
    public void SecondaryShoot() {
        if(Input.GetKeyDown(KeyCode.Mouse1)) {
            if(currentGrenade)
            currentGrenade.GetComponent<GrenadeBehaviour>().Explode();            
        }
    }
}
