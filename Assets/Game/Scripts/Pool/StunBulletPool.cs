using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunBulletPool : ObjectPool<StunerBullet>
{

    public List<StunerBullet> activeBullets = new List<StunerBullet>();

    private void Update()
    {
        if (activeBullets.Count > 0)
        {
            for (int i = activeBullets.Count - 1; i >= 0; i--)
            {
                StunerBullet bullet = activeBullets[i];
                if (!bullet.IsAlive)
                {
                    activeBullets.RemoveAt(i);
                    ReturnObject(bullet);
                }
            }
        }
    }

    public void AddBullet(StunerBullet b)
    {
        activeBullets.Add(b);
    }

}
