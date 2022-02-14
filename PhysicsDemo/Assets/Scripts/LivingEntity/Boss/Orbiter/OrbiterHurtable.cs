using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterHurtable : MonoBehaviour, IHurtable
{
    [SerializeField] private float _recoveryTime;
    [SerializeField] private float _recoveryTimeMax = 0.5f;
    [SerializeField] private IEntity _owner;
    [SerializeField] private IReactsToHit _onHit;

    private void Awake()
    {
        _recoveryTimeMax = 0.1f;
        _onHit = gameObject.GetComponent<IReactsToHit>();
        _owner = gameObject.GetComponent<IEntity>();
    }

    void OnTriggerEnter(Collider other)
    {
        CollideWithHitbox(other);
    }

    private void Update()
    {
        _recoveryTime -= Time.deltaTime;
    }

    public bool CollideWithHitbox(Collider other)
    {
        if (other.CompareTag("Hitbox"))
        {
            Hitbox box = other.gameObject.GetComponent<Hitbox>();
            if (_recoveryTime <= 0.0001)
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
                if (targetFacer != null)
                {
                    targetFacer.SetLastHitbox(box);
                }
                return true;
            }
        }

        return false;
    }
}
