using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehaviour : MonoBehaviour
{
    public Gun[] weapons;
    private int weaponIndex;

    private void Start()
    {
        weaponIndex = 0;
        UpdateWeapons();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                weaponIndex = 0;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                weaponIndex = 1;
            UpdateWeapons();
            Debug.Log(weaponIndex);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapons[weaponIndex].Shoot();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            weapons[weaponIndex].Reload();
        }
    }
    private void UpdateWeapons()
    {
        foreach (Gun g in weapons)
        {
            g.gameObject.SetActive(false);
        }
        weapons[weaponIndex].gameObject.SetActive(true);
    }
}
