using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour {
    public Gun[] weapons;
    public Gun firstWeapon;
    public Gun secondaryWeapon;
    private Gun currentWeapon;
    private int weaponIndex;

    private void Start() {
        currentWeapon = firstWeapon;
    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Q))
            ChangeWeapons();

        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            currentWeapon.Shoot();
        }
        if(Input.GetKeyDown(KeyCode.R)) {
            currentWeapon.Reload();
        }
    }

    private void ChangeWeapons() {
        if(firstWeapon.isActiveAndEnabled)
        {
            firstWeapon.gameObject.SetActive(false);
            secondaryWeapon.gameObject.SetActive(true);
            currentWeapon = secondaryWeapon;
        }
        else
        {
            firstWeapon.gameObject.SetActive(true);
            secondaryWeapon.gameObject.SetActive(false);
            currentWeapon = firstWeapon;
        }
    }

    private void SetSecondaryWeapon(int index) {
        if(secondaryWeapon)
        {
            secondaryWeapon.gameObject.SetActive(false);
        }
        firstWeapon.gameObject.SetActive(false);
        secondaryWeapon = weapons[index];
        secondaryWeapon.gameObject.SetActive(true);
        currentWeapon = secondaryWeapon;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "WeaponItem")
        {
            SetSecondaryWeapon(other.GetComponent<WeaponItem>().GetIndex());
            Destroy(other.gameObject);
        }
    }

}
