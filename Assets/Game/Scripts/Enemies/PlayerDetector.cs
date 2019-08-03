using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour {

    public bool isPlayerInside = false;
    public LayerMask layerMask;
    public Transform player;
    private bool checkPlayerOnSight = false;
    private void Start()
    {
        layerMask = 1 << 1;
    }
    private void Update()
    {
        RaycastHit hit;
        if(checkPlayerOnSight && player)
        {
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
            {
                if(hit.transform.gameObject.tag == "Player")
                    isPlayerInside = true;
                else
                    isPlayerInside = false;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            checkPlayerOnSight = true;
            player = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            checkPlayerOnSight = false;
            player = null;
        }
    }
}
