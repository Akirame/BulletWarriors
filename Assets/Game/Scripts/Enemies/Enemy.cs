using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public int speed;
	public float minDistanceAttack;

	private GameObject player;

	private void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
		tag = "Enemy";
	}

	public GameObject GetPlayer() {
		return player;
	}

	public virtual void Kill() {
	}

}
