using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterZone : MonoBehaviour {

    public GameObject[] itemList;
    public Transform itemPosition;

    private void CreateWeapon(WeaponZone wz) {
        Instantiate(itemList[Random.Range(0, itemList.Length)], itemPosition.position, Quaternion.identity, transform);
    }

	// Use this for initialization
	void Start () {
        WeaponZone.OnZoneComplete += CreateWeapon;
	}
	
}
