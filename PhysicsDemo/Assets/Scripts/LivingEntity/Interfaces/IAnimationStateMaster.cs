using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationStateMaster
{
    public void SetDeadState(bool isDead);
    public void SetGroundedState(bool isGrounded);
    public void SetStaggerState(float stagger);
    public void SetAttackState(int attackState);
    public void SetVelocityState(float velocity);

    public bool GetDeadState();
    public bool GetGroundedState();
    public float GetStagger();
    public int GetAttackState();
    public float GetNormalizedSpeedState();
}
