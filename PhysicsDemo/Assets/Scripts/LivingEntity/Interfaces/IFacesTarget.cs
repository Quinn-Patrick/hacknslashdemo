using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFacesTarget
{
    public void FaceTarget(ICharacterModel model);
    public float GetFacingAngle();

    public void SetLastHitbox(Hitbox box);
}
