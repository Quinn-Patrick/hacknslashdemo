using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovementMaster
{
    public void MovementLogic();
    public Vector3 GetSpeed();
    public IKnockbackSystem GetKnockbackSystem();
    public SpeedSystem GetSpeedSystem();
    public MovementController GetMovementSystem();

}
