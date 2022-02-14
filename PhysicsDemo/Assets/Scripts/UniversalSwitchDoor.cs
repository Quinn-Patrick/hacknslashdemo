using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalSwitchDoor : MonoBehaviour
{
    void Update()
    {
        bool opened = true;
        foreach(bool b in Game.UniversalSwitchesPressed)
        {
            if (!b)
            {
                opened = false;
            }
        }
        if (opened)
        {
            gameObject.SetActive(false);
        }
    }
}
