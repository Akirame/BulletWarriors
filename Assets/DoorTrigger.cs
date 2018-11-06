using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public delegate void DoorActions(DoorTrigger d);
    public DoorActions TriggerOn;
    public enum TypeOf { Open, Close };
    public TypeOf type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            TriggerOn(this);
    }
}
