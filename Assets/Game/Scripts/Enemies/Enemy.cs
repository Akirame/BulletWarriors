using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void EnemyActions(Enemy e);
    public static EnemyActions OnDieWithBullet;
    public float health = 3;
    private bool powerUpDroped = false;
    public ItemPool ItemPool;
    public bool alive = true;
    public Collider coll;
    private float timer;

	private void Awake() {
		tag = "Enemy";
	}

    public virtual void TakeDamage(float _hit)
    {
        if (alive)
        {
            health -= _hit;
            if (health <= 0)
            {
                DropPowerUp();
                alive = false;
            }
        }
    }

    protected void Update()
    {
        if (!alive)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                Kill();
            }
        }
    }

    private void Kill()
    {
        coll.isTrigger = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    public void DropPowerUp()
    {
        if (UnityEngine.Random.Range(0f, 1f) > 0.1f && !powerUpDroped)
        {
            powerUpDroped = true;
            var powerUp = ItemPool.Get();
            if (powerUp == null)
            {
                return;
            }
            powerUp.Spawn(transform.position);
            ItemPool.AddItem(powerUp);
        }
    }
}
