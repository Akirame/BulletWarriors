using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void EnemyActions(Enemy e);
    public static EnemyActions OnDieWithBullet;
    public float health = 3;
    private bool powerUpDroped = false;
    public ItemPool ItemPool;

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
