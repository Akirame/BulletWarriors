using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun
{
    public override void Shoot(float damageMultiplier, bool fromPlayer)
    {
        if (CanShoot())
        {
            canShoot = false;
            anim.SetTrigger("Fire");
            var bullet = bp.Get();
            if (bullet == null)
            {
                return;
            }
            bullet.Spawn(shootPoint.position, shootPoint.forward, weaponDamage * damageMultiplier, fromPlayer);
            bp.AddBullet(bullet);
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            muzzleFlash.Play();
            currentAmmoOnCharger--;
        }
    }
}
