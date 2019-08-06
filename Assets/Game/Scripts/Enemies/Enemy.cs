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
    public bool receivingDamage = false;
    private ParticleSystem hitParticles;
    public AudioSource audioSource;
    public AudioClip damagedAudio;

	private void Awake() {
		tag = "Enemy";
        ItemPool = GameObject.FindGameObjectWithTag("ItemPool").GetComponent<ItemPool>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
	}

    public virtual void TakeDamage(float _hit,Vector3 hitPosition)
    {
        if (alive)
        {
            receivingDamage = true;
            health -= _hit;
            hitParticles.transform.position = hitPosition;
            hitParticles.Play();
            audioSource.clip = damagedAudio;
            audioSource.Play();
            if (health <= 0)
            {
                DropPowerUp();
                alive = false;
            }
        }
    }
    public virtual void TakeDamage(float _hit)
    {
        if(alive)
        {
            health -= _hit;
            hitParticles.Play();
            if(health <= 0)
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
            if (timer > 1.5f)
            {
                Kill();
            }
            if (timer > 4)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void Kill()
    {
        coll.isTrigger = true;
        var rig = GetComponent<Rigidbody>();
        rig.constraints = RigidbodyConstraints.None;
        rig.useGravity = true;
    }

    public void DropPowerUp()
    {
        if (ItemPool && UnityEngine.Random.Range(0f, 1f) > 0.1f && !powerUpDroped)
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
