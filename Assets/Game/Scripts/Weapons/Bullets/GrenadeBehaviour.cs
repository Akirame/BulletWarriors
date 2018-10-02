using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour 
    {
    public float speed;
    public float lifeTime;
    public float gravity;
    public GameObject explosionPrefab;

    private Rigidbody rig;
    private Vector3 direction;
    private float lifeTimer;
    private bool exploding = false;
    private void Awake() {
        rig = GetComponent<Rigidbody>();
    }

    private void Update() {        
        lifeTimer += Time.deltaTime;
        if(lifeTimer >= lifeTime) {
            Explode();
        }
    }

    public void Explode() {
        if(!exploding) {
            exploding = true;
            Instantiate(explosionPrefab, transform.position, transform.rotation, transform.parent);
            EZCameraShake.CameraShaker.Instance.ShakeOnce(5f, 5f, 0.1f, 1.0f);
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector3 dir) {
        direction = dir;        
        rig.velocity = speed * direction * Time.deltaTime;        
    }

    public void Kill() {
        Destroy(gameObject);
    }
}
