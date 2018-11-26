using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour {

    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !activated)
        {
            activated = true;
            GameManager.GetInstance().gameStarted = true;
        }
    }

}
