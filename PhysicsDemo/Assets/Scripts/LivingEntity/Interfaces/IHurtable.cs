using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHurtable
{
    public bool CollideWithHitbox(Collider other);
}
