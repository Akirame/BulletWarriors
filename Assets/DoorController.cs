using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public DoorTrigger openDoorTrigger;
    public DoorTrigger closeDoorTrigger;
    public BoxCollider doorCollider;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        closeDoorTrigger.TriggerOn += DoorTriggerEnter;
        openDoorTrigger.TriggerOn += DoorTriggerEnter;
    }

    public void DisableDoorCollider()
    {
        doorCollider.enabled = false;
    }
    public void EnableDoorCollider()
    {
        doorCollider.enabled = true;
    }
    private void DoorTriggerEnter(DoorTrigger d)
    {
        switch (d.type)
        {
            case DoorTrigger.TypeOf.Open:
                anim.SetTrigger("openDoor");
                break;
            case DoorTrigger.TypeOf.Close:
                anim.SetTrigger("closeDoor");
                EnableDoorCollider();
                break;
        }
    }
}
