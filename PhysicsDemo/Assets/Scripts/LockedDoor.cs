using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LockedDoor : Entity
{
    public static event Action DoorUnlocked;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hitbox"))
        {
            Hitbox box = other.gameObject.GetComponent<Hitbox>();
            IKeyCounter playerKeyCollection = box.transform.parent.gameObject.GetComponent<IKeyCounter>();
            if (box.gameObject.layer == 3 || box.gameObject.layer == 11)
            {
                if(playerKeyCollection == null)
                {
                    return;
                }
                if (playerKeyCollection.GetScore() > 0)
                {
                    DoorUnlocked?.Invoke();
                    playerKeyCollection.AlterScore(-1);
                    gameObject.SetActive(false);
                }
            }
        }
    }

    
}
