using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolver : Gun
{
    public override void Shoot()
    {
        GameObject go = Instantiate(bullet.gameObject, shootPoint.transform.position, Quaternion.identity);
        go.GetComponent<BulletBehaviour>().SetDirection(shootPoint.transform.forward);
    }
}
