using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool<BulletBehaviour>
{

    private List<BulletBehaviour> activeBullets;

    private void Update()
    {
        for (int i = 0; i < activeBullets.Count - 1; i--)
    {
            var bullet = activeBullets[i];
            if (!bullet.IsAlive)
            {
                activeBullets.RemoveAt(i);
                ReturnObject(bullet);
            }
        }
    }

    public void AddBullet(BulletBehaviour b)
    {
        activeBullets.Add(b);
    }

}
