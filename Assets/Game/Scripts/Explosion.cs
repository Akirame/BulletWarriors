using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public float explosionRadius;
    public float explosionAcceleration;

    // Update is called once per frame
    void Update() {
        Explode();
    }

    private void Explode()
    {
        float currentRadius = GetComponent<SphereCollider>().radius;
        if (currentRadius < explosionRadius)
        {
            currentRadius += Time.deltaTime * explosionAcceleration;
            GetComponent<SphereCollider>().radius = currentRadius;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 dir = other.transform.position - transform.position;
            dir = dir.normalized;
            other.gameObject.GetComponent<Player>().Knockback(dir);
        }
    }
}
