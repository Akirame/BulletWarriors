using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public int pellets = 10;
    public float inaccurracy = 0.2f;
    public override void Shoot(float damageMultiplier, bool fromPlayer)
    {
        if (CanShoot())
        {
            canShoot = false;
            anim.SetTrigger("Fire");
            for (int i = 0; i < pellets; i++)
            {
                var bullet = bp.Get();
                if (bullet == null)
                {
                    return;
                }
                bullet.Spawn(shootPoint.position, shootPoint.forward + (Random.insideUnitSphere * inaccurracy), weaponDamage * damageMultiplier, fromPlayer);
                bp.AddBullet(bullet);
                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                muzzleFlash.Play();
            }
            currentAmmoOnCharger--;
        }
    }
}
