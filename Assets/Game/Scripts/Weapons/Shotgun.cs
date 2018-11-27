using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public int pellets = 10;
    public float inaccurracy = 0.2f;
    public override void Shoot(int damageMultiplier, bool fromPlayer)
    {
        if (CanShoot())
        {
            for (int i = 0; i < pellets; i++)
            {
                GameObject go = Instantiate(bullet.gameObject, shootPoint.transform.position, Quaternion.identity, bulletGroup);
                BulletBehaviour b = go.GetComponent<BulletBehaviour>();
                b.SetDirection((transform.forward + (Random.insideUnitSphere * inaccurracy)));
                b.SetDamage(weaponDamage * damageMultiplier);
                b.SetFromPlayer(fromPlayer);
                go.transform.rotation = shootPoint.transform.rotation;                
            }
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            muzzleFlash.Play();
            currentAmmo--;
        }
    }            
}
