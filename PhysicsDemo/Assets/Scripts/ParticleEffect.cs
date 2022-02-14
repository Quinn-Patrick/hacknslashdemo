using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ParticleEffect : MonoBehaviour
{
    private float lifeTime;
    private bool ready = false;
    VisualEffect vfx;
    // Start is called before the first frame update
    void Start()
    {
        vfx = GetComponent<VisualEffect>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if(ready)
        {            
            vfx.Play();
            ready = false;
        }
        lifeTime += Time.deltaTime;
        if (vfx.HasFloat("MaxLifetime"))
        {
            if (lifeTime > vfx.GetFloat("MaxLifetime"))
            {
                vfx.Stop();
                Game.EffectPool.ReturnParticleEffect(this);
            }
        }

    }
    private void OnEnable()
    {
        vfx = GetComponent<VisualEffect>();
        ready = true;        
        lifeTime = 0;
        vfx.transform.position = transform.position;
        
    }

    private void OnDisable()
    {
        //vfx.Stop();
    }
}
