using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Game : MonoBehaviour {

    public Text timerText;
    public Text bulletsText;    
    private GameManager gm;
    private int timer;
    private int weaponAmmo;
    private int weaponMaxAmmo;
    private int weaponChargers;

	void Start () {
        WeaponBehaviour.OnWeaponChange += DrawWeaponsText;
        timer = 0;
        weaponAmmo = 0;
        weaponMaxAmmo = 0;
        weaponChargers = 0;
        gm = GameManager.GetInstance();
        DrawTimerText();
	}
	
	// Update is called once per frame
	void Update () {
        if (timer != (int)gm.totalTime)
        {
            DrawTimerText();
        }
	}
    void DrawWeaponsText(int currentAmmo, int maxAmmoPerCharger, int chargers)
    {
        if (weaponAmmo != currentAmmo || weaponMaxAmmo != maxAmmoPerCharger || weaponChargers != chargers)
        {
            weaponAmmo = currentAmmo;
            weaponMaxAmmo = maxAmmoPerCharger;
            weaponChargers = chargers;
            bulletsText.text = currentAmmo + "/" + maxAmmoPerCharger + " x" + chargers;
        }
    }
    void DrawTimerText()
    {
        timer = (int)gm.totalTime;
        timerText.text = timer.ToString("000");
    }
}
