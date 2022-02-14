using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class KeyCollector : MonoBehaviour, ITriggerCollider
{
    [SerializeField] private IKeyCounter _collection;
    const string TargetString = "Key";
    public static event Action KeyCollected;


    void Start()
    {
        _collection = gameObject.GetComponent<IKeyCounter>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(TargetString))
        {
            KeyCollected?.Invoke();
            if (_collection == null) return;
            _collection.AlterScore(1);
            other.gameObject.SetActive(false);
        }
    }
}
