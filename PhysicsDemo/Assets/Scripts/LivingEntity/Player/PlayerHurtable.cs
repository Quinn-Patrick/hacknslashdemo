using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtable : MonoBehaviour, IHurtable
{
    [SerializeField] private float _recoveryTime;
    [SerializeField] private float _recoveryTimeMax = 0.5f;
    [SerializeField] private IEntity _owner;
    [SerializeField] private IReactsToHit _onHit;

    private void Awake()
    {
        _onHit = gameObject.GetComponent<IReactsToHit>();
        _owner = gameObject.GetComponent<IEntity>();
    }

    void OnTriggerEnter(Collider other)
    {
        CollideWithHitbox(other);
    }
    public bool CollideWithHitbox(Collider other)
    {
        if (other.CompareTag("Hitbox"))
        {
            Hitbox box = other.gameObject.GetComponent<Hitbox>();
            if (_recoveryTime <= 0.0001 && box != null)
            {    
                _recoveryTime = _recoveryTimeMax;
                if (_onHit != null)
                {
                    _onHit.OnHit(box);
                }

                Game.EffectPool.GetParticleEffect(this.transform.position, box._vfx);
                SoundManager.Instance.PlaySound(box._hitSound);
                
                box._target = _owner;

                IFacesTarget targetFacer = box.transform.parent.gameObject.GetComponent<IFacesTarget>();
                if(targetFacer != null)
                {
                    targetFacer.SetLastHitbox(box);
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        _recoveryTime -= Time.deltaTime;
    }
}
