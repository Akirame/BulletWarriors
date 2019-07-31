using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Game : MonoBehaviour
{


    #region singleton
    private static UI_Game instance;
    public static UI_Game GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    #endregion


    public Text timerText;
    public Text currentAmmoText;
    public Text totalAmmoText;
    public Text winText;
    public Image energyBar;
    public Image healthBar;
    public Image damageImage;
    public Image stunedImage;
    public BulletTimeBehaviour BTB;
    public Player player;
    private float currentEnergy = 0f;
    private float currenLife = 0f;
    private GameManager gm;
    private int gameTimer;
    private int weaponAmmo;
    private int weaponTotalAmmo;
    private Animator anim;
    public GameObject MobileControlsCanvas;

    void Start()
    {
        WeaponBehaviour.OnWeaponChange += DrawWeaponsText;
        Player.OnHit += PlayerDamaged;
        Player.OnStuned += PlayerStuned;
        weaponAmmo = 0;
        weaponTotalAmmo = 0;
        gm = GameManager.GetInstance();
        player = gm.player;
        DrawTimerText();
        anim = GetComponent<Animator>();
        MobileControlsCanvas.SetActive(false);
#if UNITY_ANDROID
        MobileControlsCanvas.SetActive(true);
#endif
    }

    internal void WinState()
    {
        winText.gameObject.SetActive(true);
    }

    private void PlayerStuned(float time)
    {
        anim.SetTrigger("Stuned");
    }

    private void PlayerDamaged(Player p)
    {
        anim.SetTrigger("Damaged");
    }

    public void ItemPicked()
    {
        anim.SetTrigger("Pick");
    }

    // Update is called once per frame
    void Update()
    {
        DrawTimerText();
        DrawEnergyBar();
        DrawHealthBar();
    }

    void DrawEnergyBar()
    {
        if (currentEnergy != BTB.energyBar)
        {
            currentEnergy = BTB.energyBar;
            energyBar.fillAmount = currentEnergy / BTB.maxEnergy;
        }
    }

    void DrawHealthBar()
    {
        if (currenLife != player.life)
        {
            currenLife = player.life;
            healthBar.fillAmount = currenLife / player.maxLife;
        }
    }

    void DrawWeaponsText(int ammoOnCharger, int totalAmmo)
    {
        if (weaponAmmo != ammoOnCharger || weaponTotalAmmo != totalAmmo)
        {
            weaponAmmo = ammoOnCharger;
            weaponTotalAmmo = totalAmmo;
            currentAmmoText.text = ammoOnCharger.ToString();
            totalAmmoText.text = "/" + totalAmmo.ToString();
        }
    }
    void DrawTimerText()
    {
        int min = (int)Mathf.Floor((int)gm.totalTime / 60);
        int seconds = (int)Mathf.Floor((((gm.totalTime / 60) - min)) * 60);
        timerText.text = min.ToString() + ":" + seconds.ToString("00");
    }

    public void ActivateAllUI(Gun weapon)
    {
        currentAmmoText.gameObject.SetActive(true);
        totalAmmoText.gameObject.SetActive(true);
        DrawWeaponsText(weapon.currentAmmoOnCharger, weapon.totalAmmo);
    }

    private void OnDestroy()
    {
        WeaponBehaviour.OnWeaponChange -= DrawWeaponsText;
    }

}
