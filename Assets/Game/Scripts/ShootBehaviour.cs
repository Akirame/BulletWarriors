using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    public bulletBehaviour bullet;
    public GameObject shootPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject go = Instantiate(bullet.gameObject, shootPoint.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().velocity = transform.TransformDirection(0, 0, 25);
            go.transform.rotation = shootPoint.transform.rotation;
        }
    }
}
