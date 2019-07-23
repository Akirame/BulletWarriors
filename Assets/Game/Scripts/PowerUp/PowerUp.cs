using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    private enum POWER_TYPE {DAMAGE, HEALTH, AMMO, LAST }
    private POWER_TYPE type;
    public float disappearTime = 10;
    private float timer = 0;
    public bool IsAlive = false;
    public Transform meshList;

    private void Update()
    {
        if (IsAlive)
        {
            timer += Time.deltaTime;
            if (timer > disappearTime)
            {
                Kill();
            }
        }
    }

    private void Kill()
    {
        timer = 0;
        IsAlive = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            WeaponBehaviour wb = other.gameObject.GetComponent<WeaponBehaviour>();
            switch (type)
            {
                case POWER_TYPE.DAMAGE:
                    wb.DoubleDamage();
                    Kill();
                    break;
                case POWER_TYPE.HEALTH:
                    other.GetComponent<Player>().RestoreLife(25);
                    break;
                case POWER_TYPE.AMMO:
                    wb.AddAmmoWeaponsEquiped(30);
                    break;
                case POWER_TYPE.LAST:
                    break;
                default:
                    break;
            }
            Kill();
        }
    }

    internal void Spawn(Vector3 position)
    {
        gameObject.SetActive(true);
        GetRandomPower();
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = position + new Vector3(0,1,0);
        IsAlive = true;
    }

    private void GetRandomPower()
    {
        type = (POWER_TYPE)UnityEngine.Random.Range(0, (int)POWER_TYPE.LAST);
        for (int i = 0; i < meshList.childCount; i++)
        {
            meshList.GetChild(i).gameObject.SetActive(i == (int)type);
        }
    }
}
