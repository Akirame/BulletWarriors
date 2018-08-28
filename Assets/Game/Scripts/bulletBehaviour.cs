using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    public float speed;
	public float lifeTime;

	private Rigidbody rig;
	private Vector3 direction;
	private float lifeTimer;

	private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rig.velocity = speed * direction * Time.deltaTime;
		lifeTimer += Time.deltaTime;
		if (lifeTimer >= lifeTime) {
			Destroy(gameObject);
		}
    }

	public void SetDirection(Vector3 dir) {
		direction = dir;
	}

	public void Kill() {
		Destroy(gameObject);
	}
}
