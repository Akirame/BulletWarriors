using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void EnemyActions(Enemy e);
    public static EnemyActions OnDieWithBullet;
    public GameObject powerUp;
    public float health = 3;
    private bool powerUpDroped = false;

	private void Awake() {
		tag = "Enemy";
	}

    public virtual void TakeDamage(int _hit)
    {
        health -= _hit;
        if (health <= 0)
        {
            DropPowerUp();
            Destroy(gameObject);
        }
    }

    public void DropPowerUp()
    {
        if (powerUp)
        {
            if (UnityEngine.Random.Range(0f,1f) > 0.3f && !powerUpDroped)
            {
                powerUpDroped = true;
                Instantiate(powerUp, transform.position, Quaternion.identity, transform.parent);
            }
        }
    }

}
