using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    public enum POWER_TYPE {DAMAGE, HEALTH, AMMO, LAST }
    public POWER_TYPE type;


    private void Start()
    {
        type = (POWER_TYPE)Random.Range(0, (int)POWER_TYPE.LAST);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            WeaponBehaviour wb = other.gameObject.GetComponent<WeaponBehaviour>();
            switch (type)
            {
                case POWER_TYPE.DAMAGE:
                    wb.damageMultiplier *= 1.1f;
                    break;
                case POWER_TYPE.HEALTH:
                    other.GetComponent<Player>().RestoreLife(25);
                    break;
                case POWER_TYPE.AMMO:
                    wb.ResetWeaponsEquipedAmmo();
                    break;
                default:
                    break;
            }
            Destroy(gameObject);
        }
    }

}
