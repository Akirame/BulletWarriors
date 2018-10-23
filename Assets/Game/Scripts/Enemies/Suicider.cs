using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicider : Enemy {


	enum STATES { CHASING, ATTACKING };
	public GameObject explosionPrefab;

	private Vector3 direction;
	private STATES currentState;
	public bool exploding;

	// Use this for initialization
	void Start() {
		currentState = STATES.CHASING;
		exploding = false;
	}

	private void Update() {
		StateController();
	}

	private void StateController() {
		switch (currentState) {
			case STATES.CHASING:
				ChasePlayer();
				break;
			case STATES.ATTACKING:
				Explode();
                Destroy(this.gameObject);
				break;
			default:
				break;
		}
	}

	private void Explode() {
		if (!exploding) {
			exploding = true;
			Instantiate(explosionPrefab, transform.position, transform.rotation, transform.parent);	            
		}
	}

	private void ChasePlayer() {
		if (GetPlayer()) {
			Vector3 positionDifference = GetPlayer().transform.position - transform.position;            
			direction = positionDifference.normalized;
			GetComponent<Rigidbody>().velocity = direction * speed * Time.deltaTime;
			if (Vector3.Distance(GetPlayer().transform.position, transform.position) <= 0.5 /* NUMERO MAFICO A ELIMINAR*/ ) {
				currentState = STATES.ATTACKING;
			}
		}
	}
    public override void TakeDamage(float _hit)
    {
        health -= _hit;
        if (health <= 0)
        {
            Explode();
            Kill();
        }
    }
}
