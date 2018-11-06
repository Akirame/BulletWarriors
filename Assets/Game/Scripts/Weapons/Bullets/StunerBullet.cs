using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunerBullet : BulletBehaviour {

    public float stunTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Player>().Stun(stunTime);
        }
    }

}
