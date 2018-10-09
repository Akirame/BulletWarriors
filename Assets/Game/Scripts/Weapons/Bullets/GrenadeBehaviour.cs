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

        if(transform.localScale.x < 1)
        transform.localScale = Vector3.one * lifeTimer * 3;

        if (lifeTimer >= lifeTime) {            
            Explode();
        }
    }

    public void Explode() {
        if(!exploding) {
            exploding = true;
            Instantiate(explosionPrefab, transform.position, transform.rotation, transform.parent);
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
