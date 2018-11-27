using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Explosion : MonoBehaviour {

    public int damage = 20;
    public float explosionRadius;
    public float explosionAcceleration;
    public int shakeIntensity = 20;
    public AudioClip explosionSound;


    private void Start()
    {
        Player player = GameManager.GetInstance().player;
        float playerDistance = Vector3.Distance(transform.position, player.transform.position);
        CameraShaker.Instance.ShakeOnce((float)shakeIntensity/playerDistance, 4f, 0.1f, 1f);        
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);        
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
			other.gameObject.GetComponent<Player>().TakeDamage(damage);
        }
		
		if (other.gameObject.tag == "Enemy")
		{
			other.gameObject.GetComponent<Enemy>().TakeDamage(damage);
		}
    }

	private void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);

        }
    }
}
