using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Flamethrower : Entity
{
    public float OffTime = 0f;
    public float OnTime = 0f;
    private float Timer = 0f;
    public float Offset = 0f;
    public float HitboxTimeCushion = 0.2f;
    private Hitbox box = null;
    private bool on = false;
    public VisualEffect Flames;
    public GameObject HitboxOrigin = null;
    
    // Start is called before the first frame update
    void Start()
    {        
        Flames = GetComponent<VisualEffect>();
        Flames.Stop();
        Timer = Offset;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (on)
        {
            if(Timer > OnTime)
            {
                if(box != null)
                {
                    Game.HitPool.ReturnHitbox(box);
                    box = null;
                }
                on = false;
                Flames.Stop();
                Timer = 0;
            }
            else if(Timer > HitboxTimeCushion && HitboxOrigin != null && box == null)
            {
                box = Game.HitPool.GetHitbox(this, HitboxOrigin.transform.position, this.transform.eulerAngles, 0.5f, 3, (OnTime - HitboxTimeCushion), 1, 1f, 6f);
            }
        }
        else
        {
            if (Timer > OffTime)
            {
                on = true;
                Flames.Play();
                Timer = 0;
            }
        }
    }

    
}
