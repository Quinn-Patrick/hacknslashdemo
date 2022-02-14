using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDoor : MonoBehaviour
{
    public List<Switch> Switches = new List<Switch>();

    // Update is called once per frame
    void Update()
    {
        bool opened = true;
        foreach(Switch s in Switches)
        {
            if (!s.On())
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
