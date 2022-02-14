using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour, IAttackSystem
{
    [SerializeField] InputReader _input;
    [SerializeField] ISprintSystem _sprint;
    [SerializeField] IFacesTarget _faceTarget;
    [SerializeField] ICharacterModel _characterModel;
    private bool _canAttack;
    private int _attackState;
    private float _attackTime;

    void Awake()
    {
        _input = gameObject.GetComponent<InputReader>();
        _sprint = gameObject.GetComponent<ISprintSystem>();
        _faceTarget = gameObject.GetComponent<IFacesTarget>();
    }

    void Start()
    {
        _characterModel = gameObject.GetComponent<IEntity>().GetModel();
    }

    void Update()
    {
        Attack();
    }

    public void Attack()
    {
        if (_input != null && _input.GetAttack())
        {
            if (_canAttack)
            {
                _canAttack = false;
                if (_attackState == 0)
                {
                    Attack1();
                }
                else if (_attackState == 1)
                {
                    Attack2();
                }
                else if (_attackState == 2)
                {
                    Attack3();
                }
            }
        }
        else
        {
            _canAttack = true;
        }

        if (_attackState > 0)
        {
            _input.NeutralizeDirectionalInputs();
            _attackTime -= Time.deltaTime;
            if (_attackTime < 0)
            {
                _attackTime = 0;
                _attackState = 0;
            }
        }
    }

    public int GetAttackState()
    {
        return _attackState;
    }

    private void FaceTarget()
    {
        if (_faceTarget != null)
        {
            _faceTarget.FaceTarget(_characterModel);
        }
    }

    private void Attack1()
    {
        if (_sprint != null && !_sprint.IsSprinting())
        {
            _attackState = 1;
            _attackTime = 0.5f;
        }
        else
        {
            Attack3();
        }
    }

    private void Attack2()
    {
        if (_attackTime <= 0.19f)
        {
            _attackState = 2;
            _attackTime = 0.5f;
            FaceTarget();
        }
    }

    private void Attack3()
    {
        if (_attackTime <= 0.19f)
        {
            _attackState = 3;
            _attackTime = 0.8f;
            FaceTarget();
        }
    }
}
