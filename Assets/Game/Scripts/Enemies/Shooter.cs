using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Enemy {
	public enum STATES { CHASING, SHOOTING };

	public GameObject bulletPrefab;
	public Transform shootPos;
	public float shootTime;

	private Vector3 direction;
	public STATES currentState;
	public bool shooting;
	private float shootTimer;

	// Use this for initialization
	void Start() {
		currentState = STATES.CHASING;
		shooting = false;
	}


	// Update is called once per frame
	void Update() {
		StateController();
	}

	private void StateController() {
		switch (currentState) {
			case STATES.CHASING:
				ChasePlayer();
				break;
			case STATES.SHOOTING:
				ShootControl();
				break;
			default:
				break;
		}
		transform.LookAt(GetPlayer().transform);
	}

	private void ShootControl() {
		if (!shooting) {
			shooting = true;
			GameObject bullet = Instantiate(bulletPrefab, shootPos.position, Quaternion.identity);
			bullet.GetComponent<BulletBehaviour>().SetDirection(shootPos.forward);
		}
		else {
			shootTimer += Time.deltaTime;
			if (shootTimer >= shootTime) {
				shooting = false;
				shootTimer = 0;
			}
		}
		if (Vector3.Distance(GetPlayer().transform.position, transform.position) > minDistanceAttack) {
			currentState = STATES.CHASING;
		}
	}

	private void ChasePlayer() {

		RaycastHit hit;
		Debug.DrawRay(transform.position, transform.forward * minDistanceAttack, Color.red);
		if (Physics.Raycast(transform.position,transform.forward,out hit, minDistanceAttack)) {
			if (hit.transform.tag == "Obstacle") {
				direction = transform.right; // ALGO LOCO, SE MUEVE HACIA SU DERECHA CUANDO ESTA TOSKEADO
			}
			else if (hit.transform.tag == "Player") {
				if (Vector3.Distance(GetPlayer().transform.position, transform.position) <= minDistanceAttack) {
					currentState = STATES.SHOOTING;
				}
			}
		}
		else {
			Vector3 positionDifference = GetPlayer().transform.position - transform.position;
			direction = positionDifference.normalized;
		}
		GetComponent<Rigidbody>().velocity = direction * speed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Bullet") {
			Kill();
			other.GetComponent<BulletBehaviour>().Kill();
		}
	}

	public override void Kill() {
		Destroy(gameObject);
	}
}
