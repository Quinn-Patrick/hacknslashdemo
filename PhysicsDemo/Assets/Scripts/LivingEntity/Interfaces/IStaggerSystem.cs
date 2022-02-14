using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStaggerSystem
{

    public float GetStagger();
    public void SetStagger(float stagger);
    public void AlterStagger(float deltaStagger);
}
