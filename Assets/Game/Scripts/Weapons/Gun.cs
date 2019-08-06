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
    public ParticleSystem muzzleFlash;
    public int weaponDamage;
    public BulletPool bp;
    protected Animator anim;
    protected bool canShoot = true;
    protected Camera fpsCam;
    protected LayerMask layerMask;
    public AudioClip reloadSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        fpsCam = GetComponentInParent<Camera>();
        layerMask = 1 << 0 << 8;
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
            AudioSource.PlayClipAtPoint(reloadSound, transform.position);
        }
    }

    public void WeaponSelected()
    {
        if (anim && !canShoot)
        {
            canShoot = false;
            anim.SetTrigger("Selected");
        }
    }

    private void OnBecameVisible()
    {
        canShoot = false;
        anim.SetTrigger("Selected");
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
