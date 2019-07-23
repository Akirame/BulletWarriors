using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{    
    public Transform shootPoint;
    public AudioClip shootSound;
    public int totalAmmo;
    public int currentAmmoOnCharger;
    public int clipSize;
    public abstract void Shoot(float bulletDamage, bool fromPlayer);
    public Transform bulletGroup;
    public ParticleSystem muzzleFlash;
    public int weaponDamage;
    public BulletPool bp;

    public void Reload()
    {
        if (currentAmmoOnCharger < clipSize && totalAmmo > 0)
        {
            if (totalAmmo > clipSize)
            {
                totalAmmo -= clipSize;
                currentAmmoOnCharger = clipSize;
            }
            else
            {
                currentAmmoOnCharger = totalAmmo;
                totalAmmo = 0;
            }
        }
    }
    public bool CanShoot()
    {
        if (currentAmmoOnCharger > 0)
            return true;
        else
            return false;
    }
    public void AddAmmo(int count)
    {
        totalAmmo += count;
    }

    public float GetDamage() { return weaponDamage; }
}
