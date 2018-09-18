using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun
{
    public override void Shoot()
    {
        if (CanShoot())
        {
            GameObject go = Instantiate(bullet.gameObject, shootPoint.transform.position, Quaternion.identity, bulletGroup);
            go.GetComponent<BulletBehaviour>().SetDirection(shootPoint.transform.forward);
            currentAmmo--;
        }
    }
}
