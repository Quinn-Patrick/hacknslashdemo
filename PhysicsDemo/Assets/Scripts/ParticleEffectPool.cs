using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ParticleEffectPool : ObjectPool
{
    public ParticleEffect BaseObject;
    // Start is called before the first frame update
    void Start()
    {
        Game.EffectPool = this;
        InitializePool(BaseObject, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ParticleEffect GetParticleEffect(Vector3 position, VisualEffectAsset vfx)
    {
        ParticleEffect outEffect = (ParticleEffect)TakeObject();
        outEffect.GetComponent<VisualEffect>().visualEffectAsset = vfx;
        outEffect.transform.position = position;        
        return outEffect;
    }

    public void ReturnParticleEffect(ParticleEffect obj)
    {
        obj.GetComponent<VisualEffect>().Stop();
        
        ReturnObject(obj);
    }
}
