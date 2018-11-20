using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void EnemyActions(Enemy e);
    public static EnemyActions OnDieWithBullet;
    public GameObject powerUp;
    public float health = 3;

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
        Kill();
    }
    public virtual void Kill() {
        OnDieWithBullet(this);
        DropPowerUp();
    }
    public virtual void TakeDamage(float _hit)
    {
        health -= _hit;
        if (health <= 0)
            Kill();
    }

    public void DropPowerUp()
    {
        if (powerUp)
        {
            Instantiate(powerUp, transform.position, Quaternion.identity, transform.parent);
        }
    }

}
