using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour {

    public int weaponIndex;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(2 * timer) * 0.01f, transform.position.z);
        transform.Rotate(Vector3.up, 2);
    }

    public int GetIndex() {
        return weaponIndex;
    }

}
