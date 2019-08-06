using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun
{    
    public ParticleSystem particles;

    public override void Shoot(float damageMultiplier, bool fromPlayer)
    {
        if (CanShoot())
        {
            canShoot = false;
            anim.SetTrigger("Fire");

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f) + new Vector3(0, 0, 0.5f));

            RaycastHit hit;
            
            if(Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit,layerMask))
            {
                if(hit.transform.gameObject.tag == "Enemy")
                {
                    hit.transform.GetComponent<Enemy>().TakeDamage(damageMultiplier, hit.point);
                    particles.transform.position = hit.point;
                    particles.Play();
                }
                else
                {
                    particles.transform.position = hit.point;
                    particles.Play();
                }
            }          
            AudioSource.PlayClipAtPoint(shootSound, transform.position);
            muzzleFlash.Play();
            currentAmmoOnCharger--;
        }
    }
}
