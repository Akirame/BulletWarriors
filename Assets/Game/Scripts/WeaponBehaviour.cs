using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour {
    public Gun[] weapons;
    private int weaponIndex;

    private void Start() {        
        ChangeWeapons(0);
    }
    private void Update() {

        if(Input.GetKeyDown(KeyCode.Alpha1))
            ChangeWeapons(0);
        else if(Input.GetKeyDown(KeyCode.Alpha2))
            ChangeWeapons(1);
        else if(Input.GetKeyDown(KeyCode.Alpha3))
            ChangeWeapons(2);        

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            weapons[weaponIndex].Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            weapons[weaponIndex].Reload();
        }
    }
    private void ChangeWeapons(int index) {
        weaponIndex = index;
        foreach(Gun g in weapons) {
            g.gameObject.SetActive(false);
        }
        weapons[weaponIndex].gameObject.SetActive(true);
    }
}
