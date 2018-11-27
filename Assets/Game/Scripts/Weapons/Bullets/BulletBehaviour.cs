using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float speed;
	public float lifeTime;
    public int bulletDamage = 1;
    public bool fromPlayer = false;
	private Rigidbody rig;
	private Vector3 direction;
	private float lifeTimer;

	private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rig.velocity = speed * direction * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(direction);
        lifeTimer += Time.deltaTime;
		if (lifeTimer >= lifeTime) {
            Kill();
		}
    }

	public void SetDirection(Vector3 dir) {
		direction = dir;
	}

	public void Kill() {
		Destroy(this.gameObject);
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && fromPlayer)
        {
            other.GetComponent<Enemy>().TakeDamage(bulletDamage);
            Kill();
        }
        if (other.gameObject.tag == "Props")
            Kill();
        if (other.tag == "Player" && !fromPlayer)
        {
            other.GetComponent<Player>().TakeDamage(bulletDamage);
        }
    }
    public float GetDamage(){ return bulletDamage; }
    public void SetDamage(int _damage) { bulletDamage = _damage; }
    public void SetFromPlayer(bool fp) { fromPlayer = fp; }
}
