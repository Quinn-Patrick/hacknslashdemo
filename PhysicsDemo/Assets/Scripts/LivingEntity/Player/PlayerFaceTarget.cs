using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFaceTarget : MonoBehaviour, IFacesTarget
{
    private float _facingAngle = 0f;
    private Hitbox _box;
    public void FaceTarget(ICharacterModel model)
    {
        if (_box != null && _box._target != null)
        {
            if(_box._target is LivingEntity)
            {
                if (((LivingEntity)_box._target).IsDead()) return;
            }

            Vector3 targ = _box._target.GetTransform().position;
            Vector3 pos = this.transform.position; 
            Vector2 Point_1 = new Vector2(targ.x, targ.z);
            Vector2 Point_2 = new Vector2(pos.x, pos.z);
            _facingAngle = -(Mathf.Rad2Deg * Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x))-90;
            model.ForceDirection(_facingAngle);
            _box = null;
        }
    }

    public float GetFacingAngle()
    {
        return _facingAngle;
    }

    public void SetLastHitbox(Hitbox box)
    {
        _box = box;
    }
}
