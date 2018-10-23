using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : Enemy {

    public float minDistance;
    private Vector3 direction;
    private Rigidbody rig;

	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
        transform.LookAt(GetPlayer().transform);
    }

    private void Movement()
    {
        Vector3 positionDifference = GetPlayer().transform.position - transform.position;
        direction = positionDifference.normalized;
        if (Vector3.Distance(transform.position, GetPlayer().transform.position) > minDistance)
        {
            rig.velocity = direction * speed * Time.deltaTime;
        }
        else
        {
            rig.velocity = Vector3.zero;
        }
    }
}
