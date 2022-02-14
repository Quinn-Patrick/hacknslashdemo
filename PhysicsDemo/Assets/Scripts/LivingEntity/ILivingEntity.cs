using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILivingEntity : IEntity
{
    public bool IsPlayer();
    public void Kill();
    public HealthSystem GetHealthSystem();
    
    public CharacterController GetCharacterController();
    public bool IsWalking();
    public bool IsDead();

    public void SetLastHitbox(Hitbox box);
    public float GetStagger();
    public Vector3 GetSpeed();
    public IStaggerSystem GetStaggerSystem();
    public IMovementMaster GetMovementSystem();
    public State GetDefaultState();
    public void ForceState(State state);
}
