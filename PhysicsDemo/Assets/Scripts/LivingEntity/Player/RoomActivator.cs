using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomActivator : MonoBehaviour, ITriggerCollider
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoomActivator"))
        {
            LevelActivator act = other.gameObject.GetComponent<LevelActivator>();
            act.ActivateRoom();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RoomActivator"))
        {
            LevelActivator act = other.gameObject.GetComponent<LevelActivator>();
            act.DeactivateRoom();
        }
    }
}
