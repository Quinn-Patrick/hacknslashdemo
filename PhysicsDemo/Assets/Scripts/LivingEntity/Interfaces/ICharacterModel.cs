using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterModel
{
    public void SetOwner(ILivingEntity owner);
    public void SetDirection();
    public void SetAnimation();
    public void ForceDirection(float direction);
    public Animator GetAnimator();
}
