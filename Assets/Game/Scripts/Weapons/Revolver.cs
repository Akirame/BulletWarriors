using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun
{
    public override void Shoot(float damageMultiplier, bool fromPlayer)
    {
        if (CanShoot())
        {
            GameObject go = Instantiate(bullet.gameObject, shootPoint.transform.position, Quaternion.identity, bulletGroup);
            BulletBehaviour b = go.GetComponent<BulletBehaviour>();
            b.SetDirection(shootPoint.transform.forward);
            b.SetDamage(weaponDamage * damageMultiplier);
            b.SetFromPlayer(fromPlayer);
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            go.transform.rotation = shootPoint.transform.rotation;
            muzzleFlash.Play();
            currentAmmo--;
        }
    }
}
