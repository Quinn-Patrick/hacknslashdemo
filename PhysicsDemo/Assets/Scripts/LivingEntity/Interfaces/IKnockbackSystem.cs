using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKnockbackSystem
{
    public void ApplyKnockback(Vector3 knockbackAmount);
    public Vector3 GetKnockbackSpeed();
}
