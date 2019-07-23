using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
	public float lifeTime;
    public float bulletDamage = 1;
    public bool fromPlayer = false;
	private Rigidbody rig;
	private Vector3 direction;
	private float lifeTimer;

    public bool IsAlive = false;

    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (IsAlive)
        {
            rig.velocity = speed * direction * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(direction);
            lifeTimer += Time.deltaTime;
            if (lifeTimer >= lifeTime)
            {
                Kill();
            }
        }
    }

	public void SetDirection(Vector3 dir) {
		direction = dir;
	}

	public void Kill() {
        IsAlive = false;
        lifeTimer = 0;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && fromPlayer)
        {
            other.GetComponent<Enemy>().TakeDamage(bulletDamage);
            Kill();
        }
        if (other.gameObject.tag == "Props" || other.gameObject.tag == "Door")
        {
            Kill();
        }
        if (other.tag == "Player" && !fromPlayer)
        {
            other.GetComponent<Player>().TakeDamage(bulletDamage);
        }
    }

    public void Spawn(Vector3 pos, Vector3 dir, float damage, bool _fromPlayer)
    {
        transform.position = pos;
        direction = dir;
        bulletDamage = damage;
        fromPlayer = _fromPlayer;
        IsAlive = true;
        gameObject.SetActive(true);
    }

    public float GetDamage(){ return bulletDamage; }
    public void SetDamage(float _damage) { bulletDamage = _damage; }
    public void SetFromPlayer(bool fp) { fromPlayer = fp; }
}
