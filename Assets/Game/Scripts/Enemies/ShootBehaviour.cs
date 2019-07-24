using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootBehaviour : MonoBehaviour {

    public float fireDistance;
    public float minFireTime;
    public float maxFireTime;
    private float fireTime;
    public int damage;
    public GameObject bullet;
    public Transform firePosition;
    private float timer;
    public bool canShoot = true;
    public BulletPool bp;
    private ChaseBehaviour cb;

    private void Start()
    {
        fireTime = Random.Range(minFireTime, maxFireTime);
        cb = GetComponent<ChaseBehaviour>();
    }

    // Update is called once per frame
    void Update () {

        if (cb != null && cb.alive)
        {
            if (!canShoot)
            {
                timer += Time.deltaTime;
                if (timer >= fireTime)
                {
                    canShoot = true;
                    timer = 0;
                }
            }
            else
            {
                Shoot();
            }
            firePosition.LookAt(Player.GetInstance().transform.position);
        }
	}

    public virtual void Shoot()
    {
        if (OnFireDistance())
        {
            var bullet = bp.Get();
            if (bullet == null)
            {
                return;
            }
            bullet.Spawn(firePosition.position, firePosition.forward, damage, false);
            bp.AddBullet(bullet);
            canShoot = false;
            fireTime = Random.Range(minFireTime, maxFireTime);
        }
    }

    public bool OnFireDistance()
    {
        return Vector3.Distance(transform.position,GameManager.GetInstance().player.transform.position) <= fireDistance;
    }
}
