using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

using System;

public class Switch : Entity
{
    public Material OffMaterial;
    public Material OnMaterial;
    private bool activated = false;
    public VisualEffectAsset fx;
    public static event Action SwitchActivated;

    void Update()
    {
        Renderer ren = GetComponent<Renderer>();
        if (ren != null)
        {
            if (activated)
            {
                ren.material = OnMaterial;
            }
            else
            {
                ren.material = OffMaterial;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        HitboxCollision(other);
    }

    protected void HitboxCollision(Collider other)
    {
        if (other.gameObject.CompareTag("Hitbox"))
        {
            Hitbox box = other.gameObject.GetComponent<Hitbox>();
            if (box.gameObject.layer == 3 || box.gameObject.layer == 11)
            {
                if (!activated)
                {
                    Game.EffectPool.GetParticleEffect(transform.position, fx);
                }
                activated = true;
                SwitchActivated?.Invoke();
            }
        }
    }

    public bool On()
    {
        return activated;
    }
}
