using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void EnemyActions(Enemy e);
    public static EnemyActions OnDieWithBullet;
    public GameObject[] powerUps;
    public float health = 3;
    private bool powerUpDroped = false;

	private void Awake() {
		tag = "Enemy";
	}

    public virtual void TakeDamage(float _hit)
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
        if (powerUps.Length > 0)
        {
            if (UnityEngine.Random.Range(0f,1f) > 0.45f && !powerUpDroped)
            {
                powerUpDroped = true;
                Instantiate(powerUps[UnityEngine.Random.Range(0,powerUps.Length)], transform.position, Quaternion.identity, transform.parent);
            }
        }
    }

}
