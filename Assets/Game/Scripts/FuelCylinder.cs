using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCylinder : MonoBehaviour {

	public GameObject explosionPrefab;

	private bool exploding = false;

	private void Explode() {
		if (!exploding) {
			exploding = true;
			Instantiate(explosionPrefab, transform.position, transform.rotation, transform.parent);
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Bullet") {
			Explode();
			other.GetComponent<bulletBehaviour>().Kill();
		}
	}

}
