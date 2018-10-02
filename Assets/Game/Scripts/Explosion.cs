using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Explosion : MonoBehaviour {

    public float explosionRadius;
    public float explosionAcceleration;
    public int shakeIntensity = 10;


    private void Start()
    {
        Player player = GameManager.GetInstance().player;
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        CameraShaker.Instance.ShakeOnce((float)shakeIntensity/playerDistance, 4f, 0.1f, 1f);
    }

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
