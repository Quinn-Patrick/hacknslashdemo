using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundStateChange : MonoBehaviour
{
    private ILivingEntity _self;
    [SerializeField] AudioClip _clip;
    [SerializeField] StateNumber _state;
    private StateNumber _lastState;

    private void Awake()
    {
        _self = GetComponent<ILivingEntity>();
        
    }
    private void Start()
    {
        if (_self == null) return;
        _lastState = _self.GetStateObject().GetStateNumber();
    }
    private void Update()
    {
        if (_self == null) return;
        if(_self.GetStateObject().GetStateNumber() == _state && _lastState != _state)
        {
            SoundManager.Instance.PlaySound(_clip);
        }

        _lastState = _self.GetStateObject().GetStateNumber();
    }
}
