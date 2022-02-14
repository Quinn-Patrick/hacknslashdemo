using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SpeedSystem
{
    public Vector3 ComputeSpeed(Vector3 inputs);

    public void SetBaseSpeed(float baseSpeed);

    public float GetBaseSpeed();

    public float GetRootSpeed();
    public Vector3 GetCurrentSpeed();
}

