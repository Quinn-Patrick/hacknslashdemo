using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBouncingEntity: ILivingEntity
{
    public void Bounce(Vector3 normal);
    public void Bounce(float normalAngle);
    public bool CanBounce();
    public void ForceDirection(float angle);
    public List<Orbiter> GetOrbiters();
}
