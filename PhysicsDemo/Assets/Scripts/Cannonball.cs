using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using System;

public class Cannonball : Entity
{
    public float Life;
    private bool hasStarted = false;
    public Hitbox box = null;
    public VisualEffectAsset vfx;
    public VisualEffectAsset vfx2;

    public static event Action Explode;

    void Update()
    {
        if (!hasStarted)
        {
            box = Game.HitPool.GetHitbox(this, gameObject.transform.position, Vector3.zero, 0.5f, 0, Life, 1, 0.25f, 6f);
        }
        hasStarted = true;
        Life -= Time.deltaTime;
        if(Life <= 0)
        {
            Game.CannonballPool.ReturnCannonball(this);
            Explode?.Invoke();
        }
    }

    void OnEnable()
    {
        box = null;
        hasStarted = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Game.EffectPool.GetParticleEffect(transform.position, vfx);
        Game.EffectPool.GetParticleEffect(transform.position, vfx2);
        if (box != null)
        {
            Game.HitPool.ReturnHitbox(box);
        }
        box = null;
        Game.CannonballPool.ReturnCannonball(this);
        Explode?.Invoke();
    }
}
