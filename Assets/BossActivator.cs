using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour {

    private bool activated = false;
    public Boss boss;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !activated)
        {
            activated = !activated;
            boss.ascend = true;
            GameManager.GetInstance().BossMode();
        }
    }

}
