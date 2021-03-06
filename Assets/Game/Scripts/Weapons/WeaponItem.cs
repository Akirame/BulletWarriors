﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour {

    public int weaponIndex;
    private float timer;
    public AudioClip itemPick;

    private void Update()
    {
        if (Time.timeScale>0)
        {
            timer += Time.deltaTime;
            transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Sin(2 * timer) * 0.01f, transform.position.z);
            transform.Rotate(Vector3.up, 2);
        }
    }

    public int GetIndex() {
        AudioSource.PlayClipAtPoint(itemPick,transform.position);
        return weaponIndex;
    }

}
