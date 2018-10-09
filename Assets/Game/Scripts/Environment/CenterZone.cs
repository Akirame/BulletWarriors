using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterZone : MonoBehaviour {

    public GameObject[] itemList;
    public Transform itemPosition;
    private GameObject weaponOnCenter;

    private void CreateWeapon(WeaponZone wz) {
        if(weaponOnCenter)
        {
            Destroy(weaponOnCenter);
        }
        int numRandom = Random.Range(0, itemList.Length);
        weaponOnCenter = Instantiate(itemList[numRandom], itemPosition.position, Quaternion.identity, transform);
    }

	// Use this for initialization
	void Start () {
        WeaponZone.OnZoneComplete += CreateWeapon;
	}
	
}
