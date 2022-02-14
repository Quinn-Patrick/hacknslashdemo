using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InputReader
{
    public float GetForwardBackMovement();
    public float GetLeftRightMovement();
    public bool GetSprint();
    public bool GetAttack();
    public void NeutralizeInputs();
    public void NeutralizeDirectionalInputs();
}
