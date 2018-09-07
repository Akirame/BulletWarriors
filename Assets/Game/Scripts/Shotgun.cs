using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    public int pellets = 10;
    public float inaccurracy = 0.5f;
    public override void Shoot()
    {
        if (CanShoot())
        {
            for (int i = 0; i < pellets; i++)
            {
                GameObject go = Instantiate(bullet.gameObject, shootPoint.transform.position, Quaternion.identity);
                go.GetComponent<BulletBehaviour>().SetDirection((shootPoint.transform.forward + (Random.insideUnitSphere * inaccurracy)));                
            }
            currentAmmo--;
        }
    }            
}
