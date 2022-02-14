using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurtable : MonoBehaviour, IHurtable
{
    [SerializeField] private float _recoveryTime;
    [SerializeField] private float _recoveryTimeMax = 0.5f;
    [SerializeField] private IBouncingEntity _owner;
    [SerializeField] private IReactsToHit _onHit;
    private MeshRenderer _renderer;
    public Material _baseMaterial;
    public Material _ouchMaterial;
    private void Awake()
    {
        _recoveryTimeMax = 0.1f;
        _renderer = gameObject.GetComponent<MeshRenderer>();
        _onHit = gameObject.GetComponent<IReactsToHit>();
        _owner = gameObject.GetComponent<IBouncingEntity>();
    }
    void OnTriggerEnter(Collider other)
    {
        CollideWithHitbox(other);
    }
    public bool CollideWithHitbox(Collider other)
    {
        Hitbox box = other.gameObject.GetComponent<Hitbox>();
        if (box == null) return false;
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
        return false;
    }
    void Update()
    {
        _recoveryTime -= Time.deltaTime;
        if (_recoveryTime > 0.01f || _owner.IsDead())
        {
            var hello = _ouchMaterial.color.a;
            _renderer.material = _ouchMaterial;
        }
        else
        {
            _renderer.material = _baseMaterial;
        }
    }
}
