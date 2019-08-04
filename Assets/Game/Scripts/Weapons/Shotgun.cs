using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public List<ParticleSystem> particles;
    public int pellets = 10;
    public float inaccurracy = 0.2f;

    public override void Shoot(float damageMultiplier, bool fromPlayer)
    {
        if (CanShoot())
        {
            canShoot = false;
            anim.SetTrigger("Fire");

            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f) + new Vector3(0, 0, 0.5f));

            RaycastHit hit;

            for (int i = 0; i < pellets; i++)
            {
                if(Physics.Raycast(rayOrigin, fpsCam.transform.forward + (Random.insideUnitSphere * inaccurracy), out hit, layerMask))
                {
                    if(hit.transform.gameObject.tag == "Enemy")
                    {
                        hit.transform.GetComponent<Enemy>().TakeDamage(weaponDamage * damageMultiplier, hit.point);
                        for(int j = 0; j < particles.Count; j++)
                        {
                            if(!particles[j].isPlaying)
                            {
                                particles[j].transform.position = hit.point;
                                particles[j].Play();
                                break;
                            }
                        }
                    }
                    else
                    {
                        for(int j = 0; j < particles.Count; j++)
                        {
                            if(!particles[j].isPlaying)
                            {
                                particles[j].transform.position = hit.point;
                                particles[j].Play();
                                break;
                            }
                        }
                    }
                }

                AudioSource.PlayClipAtPoint(shootSound, transform.position);
                muzzleFlash.Play();
            }
            currentAmmoOnCharger--;
        }
    }
}
