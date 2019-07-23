﻿using System.Collections;
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
    protected Animator anim;
    protected bool canShoot = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Reload()
    {
        if (currentAmmoOnCharger < clipSize && totalAmmo > 0)
        {
            canShoot = false;
            if (totalAmmo > clipSize)
            {
                totalAmmo -= clipSize - currentAmmoOnCharger;
                currentAmmoOnCharger = clipSize;
            }
            else
            {
                currentAmmoOnCharger = totalAmmo;
                totalAmmo = 0;
            }
            anim.SetTrigger("Reload");
        }
    }
    public bool CanShoot()
    {
        return canShoot && currentAmmoOnCharger > 0;
    }

    public void AddAmmo(int count)
    {
        totalAmmo += count;
    }

    public void SetCanShoot(int val)
    {
        canShoot = val == 1; // MUY BUEN TRABAJO UNITY EN NO PODER CALLEAR FUNCIONES CON PARAMETRO BOOLEANO EN LAS ANIMACIONES!!!!!!!11111
    }

    public float GetDamage() { return weaponDamage; }
}
