using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float explosionRadius;
    public float explosionAcceleration;

    // Update is called once per frame
    void Update() {
        Explode();
    }

    private void Explode()
    {
        float currentRadius = GetComponent<SphereCollider>().radius;
        if (currentRadius < explosionRadius)
        {
            currentRadius += Time.deltaTime * explosionAcceleration;
            GetComponent<SphereCollider>().radius = currentRadius;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
		if (other.gameObject.tag == "Player")
        {
			other.gameObject.GetComponent<Player>().GetDamage();
        }
		
		if (other.gameObject.tag == "Enemy")
		{
			other.gameObject.GetComponent<Enemy>().Kill();
		}
    }

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Enemy") {
			collision.gameObject.GetComponent<Enemy>().Kill();
		}
	}
}
