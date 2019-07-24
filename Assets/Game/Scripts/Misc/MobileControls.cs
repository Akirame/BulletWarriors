using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour {
    
    public FixedJoystick moveJoystick;
    public FixedButton timeButton;
    public FixedTouchField touchField;
    public FixedButton shootButton;
    public FixedButton reloadButton;
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
        fps.m_MouseLook.lookAxis = touchField.TouchDist;
        weapons.buttonReload = reloadButton.Pressed;
        weapons.buttonShoot = shootButton.Pressed;
        reloadButton.Pressed = false;
        shootButton.Pressed = false;
    }

    internal void ActivateAllFunctions()
    {
        shootButton.gameObject.SetActive(true);
        reloadButton.gameObject.SetActive(true);
    }
#endif
}
