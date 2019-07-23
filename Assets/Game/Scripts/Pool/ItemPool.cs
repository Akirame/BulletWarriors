using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPool : ObjectPool<PowerUp>
{

    public List<PowerUp> activePowers = new List<PowerUp>();

    private void Update()
    {
        if (activePowers.Count > 0)
        {
            for (int i = activePowers.Count - 1; i >= 0; i--)
            {
                PowerUp power = activePowers[i];
                if (!power.IsAlive)
                {
                    activePowers.RemoveAt(i);
                    ReturnObject(power);
                }
            }
        }
    }

    public void AddItem(PowerUp b)
    {
        activePowers.Add(b);
    }

}
