using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDetector : MonoBehaviour {

    private bool canSpawn = false;

    private void OnTriggerStay(Collider other) {
        canSpawn = false;    
    }
    private void OnTriggerExit(Collider other) {
        canSpawn = true;
    }
}
