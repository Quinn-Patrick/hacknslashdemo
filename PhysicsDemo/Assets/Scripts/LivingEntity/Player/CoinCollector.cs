using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinCollector : MonoBehaviour, ITriggerCollider
{
    public static event Action CoinPickup;
    [SerializeField] private ICoinCounter _collection;
    void Awake()
    {
        _collection = gameObject.GetComponent<ICoinCounter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Coin coin = other.gameObject.GetComponent<Coin>();
            if(coin == null)
            {
                return;
            }
            Game.CoinPool.ReturnCoin(coin);
            Game.EffectPool.GetParticleEffect(coin.transform.position, coin.vfx);

            if (_collection == null) return;
            
            _collection.AlterScore(1);
            CoinPickup?.Invoke();
        }
    }
}
