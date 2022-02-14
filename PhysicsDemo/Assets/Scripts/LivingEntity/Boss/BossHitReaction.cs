using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitReaction : MonoBehaviour, IReactsToHit
{
    [SerializeField] HealthSystem _healthSystem;
    [SerializeField] IStaggerSystem _stagger;
    [SerializeField] IMovementMaster _movementMaster;
    [SerializeField] State _stateObject;
    [SerializeField] IBouncingEntity _entity;
    private float _targetAngle;
    public Vector3 _lastNormal = Vector3.zero;
    private bool _isBeingHit = false;
    private void Awake()
    {
        _healthSystem = gameObject.GetComponent<HealthSystem>();
        _entity = GetComponent<IBouncingEntity>();
    }

    public void OnHit(Hitbox box)
    {
        _isBeingHit = true;
        Vector2 Point_1 = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 Point_2 = new Vector2(box.transform.parent.transform.position.x, box.transform.parent.transform.position.z);
        float angle = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x);
        if (_stagger != null)
        {
            _stagger.SetStagger(box._stagger / 8);
        }
        TakeDamage(box);
        _entity.ForceDirection(-Mathf.Rad2Deg * angle);
        box._target = _entity;
    }

    private void TakeDamage(Hitbox box)
    {
        if(_healthSystem == null)
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
