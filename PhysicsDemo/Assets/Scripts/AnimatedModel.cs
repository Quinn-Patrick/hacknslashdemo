using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedModel : MonoBehaviour, ICharacterModel
{
    public ILivingEntity _player;
    [SerializeField]protected Animator _animator;
    protected Transform _transform;
    protected float _lastStagger;
    protected Vector3 DirectionalVector = new Vector3(1f, 0f, 0f);

    [SerializeField] protected IAnimationStateMaster _stateMaster;
    protected State _characterState;

    private void Awake()
    {
        _stateMaster = GetComponent<IAnimationStateMaster>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        if (_player != null) _characterState = _player.GetStateObject();
    }
    public void SetDirection()
    {
        Vector3 playerSpeed = _player.GetSpeed();
        if (playerSpeed.magnitude > 0 && (_player.IsWalking()))
        {
            //This is to protect it from dividing by zero or an otherwise extremely small number.
            float zSpeed = _player.GetSpeed().z;
            if (Mathf.Abs(zSpeed) < 0.00000001f)
            {
                zSpeed = 0.00000001f * Mathf.Sign(zSpeed);
            }

            float xSpeed = _player.GetSpeed().x;


            float yRotation = Mathf.Rad2Deg * (Mathf.Atan(xSpeed / zSpeed));
            DirectionalVector = new Vector3(xSpeed, 0f, zSpeed).normalized;

            if (zSpeed >= 0)
            {
                _transform.eulerAngles = new Vector3(0f, yRotation, 0f);
            }
            else
            {
                _transform.eulerAngles = new Vector3(0f, yRotation + 180, 0f);
            }
        }
    }

    public void ForceDirection(float yRotation)
    {
        _transform.eulerAngles = new Vector3(0f, yRotation, 0f);
    }
    public void SetAnimation()
    {
        _characterState = _player.GetStateObject();
        if (_stateMaster == null || _animator == null || _characterState == null)
        {
            return;
        }
        _animator.SetInteger("state", (int)_characterState.GetStateNumber());

        _animator.SetFloat("velocity", _stateMaster.GetNormalizedSpeedState());
        _animator.SetBool("isInTheAir", _stateMaster.GetGroundedState());
        _animator.SetInteger("attackState", _stateMaster.GetAttackState());
        _animator.SetBool("isDead", _stateMaster.GetDeadState());
        _animator.SetBool("isStaggered", _stateMaster.GetStagger() > 0);

        if (_player.GetStagger() > _lastStagger)
        {
            _animator.SetBool("justHit", true);
        }
        else
        {
            _animator.SetBool("justHit", false);
        }

        _lastStagger = _stateMaster.GetStagger();
    }

    public IAnimationStateMaster GetAnimationStateMaster()
    {
        return _stateMaster;
    }

    public void SetOwner(ILivingEntity owner)
    {
        _player = owner;
    }

    public Animator GetAnimator()
    {
        return _animator;
    }
}
