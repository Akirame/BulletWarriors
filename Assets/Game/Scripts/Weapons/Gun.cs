using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{    
    public Transform shootPoint;
    public GameObject bullet;
    public int totalAmmoPerCharger;
    public int chargers;
    protected int currentAmmo;
    public abstract void Shoot();
    public Transform bulletGroup;
    public ParticleSystem muzzleFlash;

    private void Start()
    {
        currentAmmo = totalAmmoPerCharger;
    }
    public void Reload()
    {
        if (chargers > 0)
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
}
