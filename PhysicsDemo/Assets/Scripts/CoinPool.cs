using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : ObjectPool
{
    public Coin BaseObject;
    void Start()
    {
        Game.CoinPool = this;
        InitializePool(BaseObject, 200);
    }
    public Coin GetCoin(Vector3 position, Vector3 force)
    {
        Coin outCoin = (Coin)TakeObject();
        outCoin.transform.position = position;
        Rigidbody rig = outCoin.GetComponent<Rigidbody>();
        if(rig != null)
        {
            rig.AddForce(force);
        }
        outCoin.time = 30f;
        outCoin.transform.eulerAngles = new Vector3(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f));

        return outCoin;
    }
    public void ReturnCoin(Coin obj)
    {
        ReturnObject(obj);
    }
}
