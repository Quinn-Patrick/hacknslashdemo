using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateMaster : MonoBehaviour, IAnimationStateMaster
{
    protected bool _isDead;
    protected float _stagger;
    protected bool _isOnGround;
    protected int _attackState;
    public float _velocity;

    public float _maxAnimatedSpeed = 12f;
    public int GetAttackState()
    {
        return _attackState;
    }

    public bool GetDeadState()
    {
        return _isDead;
    }

    public bool GetGroundedState()
    {
        return _isOnGround;
    }

    public float GetStagger()
    {
        return _stagger;
    }

    public float GetNormalizedSpeedState()
    {    
        return _velocity/_maxAnimatedSpeed;
    }

    public void SetAttackState(int attackState)
    {
        _attackState = attackState;
    }

    public void SetDeadState(bool isDead)
    {
        _isDead = isDead;
    }

    public void SetGroundedState(bool isGrounded)
    {
        _isOnGround = isGrounded;
    }

    public void SetStaggerState(float stagger)
    {
        _stagger = stagger;
    }

    public void SetVelocityState(float velocity)
    {
        _velocity = velocity;
    }
}
