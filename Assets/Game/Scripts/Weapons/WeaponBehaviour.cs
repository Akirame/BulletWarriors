using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour {
    public delegate void WeaponsChanges(int currentAmmo, int maxAmmoPerCharger, int chargers);
    public static WeaponsChanges OnWeaponChange;
    public Gun[] weapons;
    public Gun firstWeapon;
    public Gun secondaryWeapon;
    private Gun currentWeapon;
    private int weaponIndex;
    public int damageMultiplier = 1;
    public bool buttonReload = false;
    public bool buttonShoot = false;
    private void Start() {
        currentWeapon = firstWeapon;
        secondaryWeapon = null;
        //OnWeaponChange(currentWeapon.currentAmmo, currentWeapon.totalAmmoPerCharger, currentWeapon.chargers);
    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Q))
            ChangeWeapons();

        if(buttonShoot) {            
            currentWeapon.Shoot(damageMultiplier,true);
            OnWeaponChange(currentWeapon.currentAmmo, currentWeapon.totalAmmoPerCharger, currentWeapon.chargers);
        }
        if(buttonReload) {            
            currentWeapon.Reload();
            OnWeaponChange(currentWeapon.currentAmmo, currentWeapon.totalAmmoPerCharger, currentWeapon.chargers);
        }        
    }

    private void ChangeWeapons() {
        if(secondaryWeapon && firstWeapon.isActiveAndEnabled)
        {
            firstWeapon.gameObject.SetActive(false);
            secondaryWeapon.gameObject.SetActive(true);
            currentWeapon = secondaryWeapon;
        }
        else if (secondaryWeapon)
        {
            firstWeapon.gameObject.SetActive(true);
            secondaryWeapon.gameObject.SetActive(false);
            currentWeapon = firstWeapon;
        }        
        OnWeaponChange(currentWeapon.currentAmmo, currentWeapon.totalAmmoPerCharger, currentWeapon.chargers);
    }

    private void SetSecondaryWeapon(int index) {
        if(secondaryWeapon)
        {
            secondaryWeapon.gameObject.SetActive(false);
        }
        firstWeapon.gameObject.SetActive(false);
        secondaryWeapon = weapons[index];
        ResetWeaponsEquipedAmmo();
        secondaryWeapon.gameObject.SetActive(true);
        currentWeapon = secondaryWeapon;
        OnWeaponChange(currentWeapon.currentAmmo, currentWeapon.totalAmmoPerCharger, currentWeapon.chargers);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "WeaponItem")
        {
            SetSecondaryWeapon(other.GetComponent<WeaponItem>().GetIndex());
            Destroy(other.gameObject);
        }
    }

    public void ResetWeaponsEquipedAmmo()
    {
        firstWeapon.ResetAmmo();
        if (secondaryWeapon)
        {
            secondaryWeapon.ResetAmmo();
        }
        OnWeaponChange(currentWeapon.currentAmmo, currentWeapon.totalAmmoPerCharger, currentWeapon.chargers);
    }

}
