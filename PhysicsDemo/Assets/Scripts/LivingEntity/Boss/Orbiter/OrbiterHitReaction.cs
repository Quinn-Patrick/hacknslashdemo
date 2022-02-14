using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterHitReaction : MonoBehaviour, IReactsToHit
{
    [SerializeField] HealthSystem _healthSystem;
    [SerializeReference]public Boss _boss;
    private bool _isBeingHit = false;
    private void Awake()
    {
        _healthSystem = gameObject.GetComponent<HealthSystem>();
    }
    public void OnHit(Hitbox box)
    {
        _isBeingHit = true;
        Vector2 Point_1 = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 Point_2 = new Vector2(box.transform.parent.transform.position.x, box.transform.parent.transform.position.z);
        float angle = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x);
        TakeDamage(box);
        Game.EffectPool.GetParticleEffect(this.transform.position, box._vfx);
        Debug.Log($"{Mathf.Rad2Deg * angle}");
        if (_boss.CanBounce())
        {
            _boss.ForceDirection(-Mathf.Rad2Deg * angle);
        }
        box._target = GetComponent<IEntity>();
    }

    private void TakeDamage(Hitbox box)
    {
        if (_healthSystem == null)
        {
            return;
        }
        _healthSystem.AlterCurrentHealth(-box._power);
    }

    public bool WasHit()
    {
        if (!_isBeingHit)
        {
            return false;
        }
        _isBeingHit = false;
        return true;
    }
}
