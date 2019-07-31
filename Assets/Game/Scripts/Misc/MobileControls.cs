using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour {
    
    public FixedJoystick moveJoystick;
    public FixedButton timeButton;
    public FixedButton jumpButton;
    public FixedTouchField touchField;
    public FixedButton shootButton;
    public FixedButton shootButton2;
    public FixedButton reloadButton;
    public FixedButton changeWeaponButton;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;
    private WeaponBehaviour weapons;
    private BulletTimeBehaviour btb;

#if UNITY_ANDROID
    private void Start()
    {
        fps = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        weapons = GetComponent<WeaponBehaviour>();
        btb = GetComponent<BulletTimeBehaviour>();
    }
    private void Update()
    {
        fps.runAxis = moveJoystick.inputVector;
        if (timeButton.Pressed)
        {
            btb.SetConsumeEnabled(true);
            timeButton.Pressed = false;
        }
        if (jumpButton.Pressed)
        {
            fps.m_Jump = true;
        }
        fps.m_MouseLook.lookAxis = touchField.TouchDist;
        weapons.buttonReload = reloadButton.Pressed;
        weapons.buttonShoot = shootButton.Pressed;
        weapons.buttonShoot = shootButton2.Pressed;
        weapons.buttonChangeWeapon = changeWeaponButton.Pressed;
        jumpButton.Pressed = false;
        changeWeaponButton.Pressed = false;
        reloadButton.Pressed = false;
        shootButton.Pressed = false;
        shootButton2.Pressed = false;
    }

    internal void ActivateAllFunctions()
    {
        shootButton.gameObject.SetActive(true);
        shootButton2.gameObject.SetActive(true);
        reloadButton.gameObject.SetActive(true);
        changeWeaponButton.gameObject.SetActive(true);
    }
#endif
}
