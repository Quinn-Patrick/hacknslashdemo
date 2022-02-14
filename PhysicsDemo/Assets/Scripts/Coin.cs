using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using System;

public class Coin : MonoBehaviour
{
    
    public VisualEffectAsset vfx;
    public float time = 0f;
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0f)
        {
            Game.CoinPool.ReturnCoin(this);
        }
    }
}
