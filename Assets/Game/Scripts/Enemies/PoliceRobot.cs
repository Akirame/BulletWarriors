using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceRobot : MonoBehaviour {

    private ShootBehaviour sb;
    private Animator anim;
    private Rigidbody rd;

    // Use this for initialization
    void Start () {
        sb = gameObject.GetComponent<ShootBehaviour>();
        anim = GetComponentInChildren<Animator>();
        rd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (sb.OnFireDistance())
        {
            anim.SetBool("Aiming", true);
            anim.SetFloat("Speed", 0);
        }
        else
        {
            anim.SetBool("Aiming", false);
            anim.SetFloat("Speed", 12);
        }
    }
}
