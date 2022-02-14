using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitReaction : MonoBehaviour, IReactsToHit
{
    [SerializeField] HealthSystem _healthSystem;
    [SerializeField] IStaggerSystem _stagger;
    [SerializeField] IMovementMaster _movementMaster;
    [SerializeField] State _stateObject;
    [SerializeField] ILivingEntity _entity;
    [SerializeField] private float defense = 1f;
    [SerializeField] private bool _hasHitReactionSound;

    public static event Action OnAnyCharacterHit;

    void Awake()
    {
        _healthSystem = GetComponent<HealthSystem>();
        _stagger = GetComponent<IStaggerSystem>();
        _movementMaster = GetComponent<IMovementMaster>();
    }

    public void OnHit(Hitbox box)
    {
        if(_hasHitReactionSound)OnAnyCharacterHit?.Invoke();
        TakeDamage(box);

        if (_stagger != null)
        {
            _stagger.SetStagger(box._stagger);
            _entity = GetComponent<LivingEntity>();
            if (_entity != null)
            {
                _stateObject = _entity.GetStateObject();
                if (_stateObject != null)
                {
                    _entity.ForceState(_stateObject.ForceStaggerState(box._stagger));
                }
            }
        }

        Vector2 Point_1 = new Vector2(this.transform.position.x, this.transform.position.z);
        Vector2 Point_2 = new Vector2(box.transform.parent.transform.position.x, box.transform.parent.transform.position.z);
        float angle = Mathf.Atan2(Point_2.y - Point_1.y, Point_2.x - Point_1.x);
        float knock = -box._knockback;
        if (_movementMaster != null)
        {
            if (_movementMaster.GetKnockbackSystem() != null)
            {
                _movementMaster.GetKnockbackSystem().ApplyKnockback(new Vector3(knock * Mathf.Cos(angle), 0f, knock * Mathf.Sin(angle)));
            }
        }
    }

    protected void TakeDamage(Hitbox box)
    {
        if (_healthSystem != null)
        {
            _healthSystem.AlterCurrentHealth(-Mathf.RoundToInt(box._power / defense));
        }
    }
}
