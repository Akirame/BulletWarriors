﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool<BulletBehaviour>
{

    public List<BulletBehaviour> activeBullets = new List<BulletBehaviour>();

    private void Update()
    {
        if (activeBullets.Count > 0)
        {
            for (int i = activeBullets.Count - 1; i >= 0; i--)
            {
                BulletBehaviour bullet = activeBullets[i];
                if (!bullet.IsAlive)
                {
                    activeBullets.RemoveAt(i);
                    ReturnObject(bullet);
                }
            }
        }
    }

    public void AddBullet(BulletBehaviour b)
    {
        activeBullets.Add(b);
    }

}
