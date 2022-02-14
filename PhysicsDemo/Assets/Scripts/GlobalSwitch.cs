using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSwitch : Switch
{
    public int index = 0;
    private void OnTriggerEnter(Collider other)
    {
        HitboxCollision(other);
        if (On())
        {
            Game.UniversalSwitchesPressed[index] = true;
        }
    }
}
