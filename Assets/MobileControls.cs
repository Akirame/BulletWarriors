using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControls : MonoBehaviour {

    public FixedJoystick moveJoystick;
    public FixedButton jumpButton;
    public FixedTouchField touchField;
    public FixedButton shootButton;
    public FixedButton reloadButton;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fps;
    private WeaponBehaviour weapons;
    private void Start()
    {
        fps = GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();
        weapons = GetComponent<WeaponBehaviour>();
    }
    private void Update()
    {        
        fps.runAxis = moveJoystick.inputVector;
        fps.jumpAxis = jumpButton.Pressed;
        fps.m_MouseLook.lookAxis = touchField.TouchDist;        
        weapons.buttonReload = reloadButton.Pressed;            
        weapons.buttonShoot = shootButton.Pressed;        
    }

}
