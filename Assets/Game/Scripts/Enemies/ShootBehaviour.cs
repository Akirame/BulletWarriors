using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour {

    public float fireDistance;
    public float fireRate;
    public float damage;
    public GameObject bullet;
    public Transform firePosition;
    public Transform bulletList;
    private float timer;
    private bool canShoot = true;

	// Update is called once per frame
	void Update () {
        if (!canShoot)
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
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

    public virtual void Shoot()
    {
        if (OnFireDistance())
        {
            GameObject b = Instantiate(bullet, firePosition.position, Quaternion.identity, bulletList);
            BulletBehaviour bb = b.GetComponent<BulletBehaviour>();
            bb.SetDirection(firePosition.forward);
            bb.SetDamage(damage);
            canShoot = false;
        }
    }

    public bool OnFireDistance()
    {
        return Vector3.Distance(transform.position,GameManager.GetInstance().player.transform.position) <= fireDistance;
    }
}
