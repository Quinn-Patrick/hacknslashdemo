using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBlock : TriggerObject
{
    // Start is called before the first frame update
    void Start()
    {
        CoinValue = 0;
        DestroyOnContact = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
