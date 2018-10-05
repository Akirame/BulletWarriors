using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void EnemyActions(Enemy e);
    public static EnemyActions OnDieWithBullet;    
	public int speed;
	public float minDistanceAttack;


	private void Awake() {
		tag = "Enemy";
	}

	public GameObject GetPlayer() {
        return Player.GetInstance().gameObject;
	}
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player")
            PlayerTouched();
    }
    public virtual void PlayerTouched() {        
    }
    public virtual void Kill() {
        OnDieWithBullet(this);
    }
}
