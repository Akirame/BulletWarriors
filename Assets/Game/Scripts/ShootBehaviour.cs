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
			go.GetComponent<bulletBehaviour>().SetDirection(shootPoint.transform.forward);
        }
    }
}
