using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Hitbox : MonoBehaviour
{
    public float _timeLimit;
    public int _power;
    public float _stagger;
    public float _knockback;
    public bool _activated;
    public HitboxPool _parentPool = null;
    public LayerMask _mask;
    public VisualEffectAsset _vfx;
    public IEntity _target = null;
    public AudioClip _hitSound;
    public AudioClip _defaultHitSound;

    void Update()
    {
        if (!_activated)
        {
            _activated = true;
        }
        _timeLimit -= Time.deltaTime;
        if (_parentPool != null)
        {
            if (_timeLimit < 0)
            {
                _parentPool.ReturnHitbox(this);
            }
        }
    }

    private void OnEnable()
    {
        _hitSound = _defaultHitSound;
        _activated = false;
    }
}
