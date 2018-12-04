using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{    
    public Transform shootPoint;
    public GameObject bullet;
    public AudioClip shootSound;
    public int totalAmmoPerCharger;
    public int totalChargers;
    public int chargers;
    public int currentAmmo;
    public abstract void Shoot(float bulletDamage, bool fromPlayer);
    public Transform bulletGroup;
    public ParticleSystem muzzleFlash;
    public int weaponDamage;

    private void Start()
    {
        ResetAmmo();
    }
    public void Reload()
    {
        if (chargers > 0 && currentAmmo < totalAmmoPerCharger)
        {
            currentAmmo = totalAmmoPerCharger;
            chargers--;
        }
    }
    public bool CanShoot()
    {
        if (currentAmmo > 0)
            return true;
        else
            return false;
    }
    public void ResetAmmo()
    {
        currentAmmo = totalAmmoPerCharger;
        chargers = totalChargers;
    }
    public float GetDamage() { return weaponDamage; }
}
