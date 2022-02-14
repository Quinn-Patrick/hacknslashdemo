using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReactsToHit
{
    public void OnHit(Hitbox box);
}
