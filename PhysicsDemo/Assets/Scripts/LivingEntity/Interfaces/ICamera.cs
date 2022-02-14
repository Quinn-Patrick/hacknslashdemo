using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICamera
{
    public void SetTheta(float theta);
    public void SetPhi(float phi);

    public void SetTargetTheta(float theta);
}
