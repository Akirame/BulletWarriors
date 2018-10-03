using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void EnemyActions(Enemy e);
    public EnemyActions spawn;
	public int speed;
	public float minDistanceAttack;


	private void Awake() {
		tag = "Enemy";
	}

	public GameObject GetPlayer() {
        return Player.GetInstance().gameObject;
	}

	public virtual void Kill() {
	}

    private void OnTriggerStay(Collider other) {        
    }

    private void OnDestroy()
    {
        GameManager.GetInstance().totalTime += 5;
    }
}
