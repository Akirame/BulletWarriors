﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public BoxCollider doorCollider;

    private Animator anim;
    public bool opened = false;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!opened)
            {
                opened = true;
                anim.SetTrigger("openDoor");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            if (opened)
            {
                opened = false;
                anim.SetTrigger("closeDoor");
            }
        }
    }

}