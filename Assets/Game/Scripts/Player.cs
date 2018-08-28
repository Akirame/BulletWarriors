using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Knockback(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce(direction * -8000);
    }

}
