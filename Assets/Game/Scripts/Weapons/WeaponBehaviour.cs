using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour {
    public delegate void WeaponsChanges(int currentAmmo, int totalAmmo);
    public static WeaponsChanges OnWeaponChange;
    public Gun[] weaponList;
    public Gun firstWeapon;
    public Gun secondaryWeapon;
    private Gun currentWeapon;
    private int weaponIndex;
    public float damageMultiplier = 1;
    public bool buttonReload = false;
    public bool buttonShoot = false;
    public float doubleDamageTime = 5;
    private float doubleDamageTimer = 0;
    private bool hasDoubleDamage = false;

    private void Start() {
        currentWeapon = null;
        firstWeapon = null;
        secondaryWeapon = null;
    }

    private void Update() {

        if(Input.GetKeyDown(KeyCode.Q) && firstWeapon && secondaryWeapon)
            ChangeWeapons();

        if(buttonShoot && currentWeapon) {
            currentWeapon.Shoot(damageMultiplier,true);
            OnWeaponChange(currentWeapon.currentAmmoOnCharger, currentWeapon.totalAmmo);
        }
        if(buttonReload && currentWeapon) {
            currentWeapon.Reload();
            OnWeaponChange(currentWeapon.currentAmmoOnCharger, currentWeapon.totalAmmo);
        }

        if (hasDoubleDamage)
        {
            doubleDamageTimer += Time.deltaTime;
            if (doubleDamageTimer > doubleDamageTime)
            {
                doubleDamageTimer = 0;
                hasDoubleDamage = false;
                damageMultiplier = 1;
            }
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
        OnWeaponChange(currentWeapon.currentAmmoOnCharger, currentWeapon.totalAmmo);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "WeaponItem")
        {
            SetWeapon(other.GetComponent<WeaponItem>().GetIndex());
            other.gameObject.SetActive(false);
        }
    }

    private void SetWeapon(int v)
    {
        switch (v)
        {
            case 0:
                firstWeapon = weaponList[v];
                currentWeapon = firstWeapon;
                firstWeapon.gameObject.SetActive(true);
                GetComponent<MobileControls>().ActivateAllFunctions();
                UI_Game.GetInstance().ActivateAllUI();
                break;
            case 1:
                secondaryWeapon = weaponList[v];
                ChangeWeapons();
                break;
            default:
                break;
        }
    }

    public void AddAmmoWeaponsEquiped(int count)
    {
        firstWeapon.AddAmmo(count);
        if (secondaryWeapon)
        {
            secondaryWeapon.AddAmmo(count);
        }
        OnWeaponChange(currentWeapon.currentAmmoOnCharger, currentWeapon.totalAmmo);
    }

    public void DoubleDamage()
    {
        damageMultiplier = 2;
        hasDoubleDamage = true;
        doubleDamageTimer = 0;
    }

}
