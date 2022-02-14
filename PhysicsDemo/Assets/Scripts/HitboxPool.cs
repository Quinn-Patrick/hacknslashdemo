using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxPool : ObjectPool
{
    public Hitbox BaseObject;

    private void Awake()
    {
        Game.HitPool = this;
        InitializePool(BaseObject, 100);
    }
    public Hitbox GetHitbox(IEntity parent, Vector3 position, Vector3 rotation, float radius, float height, float time, int power, float stagger, float knockback)
    {
        Hitbox outBox = (Hitbox)TakeObject();
        CapsuleCollider collider = outBox.GetComponent<CapsuleCollider>();
        outBox.gameObject.transform.SetParent(parent.GetTransform());
        collider.transform.position = position;
        collider.transform.eulerAngles = rotation;
        collider.radius = radius;
        collider.height = height;

        outBox.transform.localScale.Set(radius * 2, height / 2, radius * 2);
        outBox.transform.eulerAngles = rotation;

        outBox._timeLimit = time;
        outBox._power = power;
        outBox._stagger = stagger;
        outBox._knockback = knockback;
        outBox.gameObject.layer = parent.GetAttackHitboxLayer();
        outBox._parentPool = this;
        outBox._hitSound = null;
        
        return outBox;
    }

    public Hitbox GetHitbox(IEntity parent, Vector3 position, Vector3 rotation, float radius, float height, float time, int power, float stagger, float knockback, int layer)
    {
        Hitbox outBox = GetHitbox(parent, position, rotation, radius, height, time, power, stagger, knockback);
        outBox.gameObject.layer = layer;
        return outBox;
    }

    public Hitbox GetHitbox(IEntity parent, Vector3 position, Vector3 rotation, float radius, float height, float time, int power, float stagger, float knockback, AudioClip hitSound)
    {
        Hitbox outBox = GetHitbox(parent, position, rotation, radius, height, time, power, stagger, knockback);
        outBox._hitSound = hitSound;
        return outBox;
    }

    public Hitbox GetHitbox(IEntity parent, Vector3 position, Vector3 rotation, float radius, float height, float time, int power, float stagger, float knockback, int layer, AudioClip hitSound)
    {
        Hitbox outBox = GetHitbox(parent, position, rotation, radius, height, time, power, stagger, knockback, layer);
        outBox._hitSound = hitSound;
        return outBox;
    }
    public void ReturnHitbox(Hitbox obj)
    {
        obj.gameObject.transform.SetParent(null);
        ReturnObject(obj);
    }

}
