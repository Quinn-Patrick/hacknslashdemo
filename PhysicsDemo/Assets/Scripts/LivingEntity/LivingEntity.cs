using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LivingEntity : Entity, ILivingEntity
{
    public bool _dead;
    public Controller input;
    protected bool isSprinting;
    public CharacterController _characterController;
    [SerializeField] protected bool _isPlayer;
    protected int defense = 1;
    public Hitbox _lastHitbox;
    [SerializeField] protected InputReader _inputReader;
    [SerializeField] protected HealthSystem _healthSystem;
    [SerializeField] protected IHurtable _hurtbox;
    [SerializeField] protected IStaggerSystem _stagger;
    [SerializeField] protected IMovementMaster _movementMaster;
    [SerializeField] public IAnimationStateMaster _animStates;
    public State _defaultState;
    public event Action Killed;
    private void Awake()
    {
        InitializeComponents();
    }
    void Start()
    {
        StoreSelf();
    }
    void Update()
    {
        SynchronizeStates();  
    }
    protected void SynchronizeStates()
    {
        if (_healthSystem != null)
        {
            if (_healthSystem.GetCurrentHealth() <= 0)
            {
                Kill();
            }
        }
        if (_dead)
        {
            if (_healthSystem != null)
            {
                _healthSystem.Death();
            }
        }
        if (_animStates != null)
        {
            _animStates.SetVelocityState(GetSpeed().magnitude);
            _animStates.SetDeadState(_dead);
            if (_stagger != null)
            {
                _animStates.SetStaggerState(_stagger.GetStagger());
            }
        }
        _state = _state.InterpretInput();
    }
    protected void InitializeComponents()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
        _inputReader = gameObject.GetComponent<InputReader>();
        _healthSystem = gameObject.GetComponent<HealthSystem>();
        _hurtbox = gameObject.GetComponent<IHurtable>();
        _stagger = gameObject.GetComponent<IStaggerSystem>();
        _movementMaster = gameObject.GetComponent<IMovementMaster>();
        _soundBank = gameObject.GetComponent<SoundEffectBank>();
        _state = new StateStandingPlayer(_inputReader, this, _model);
        if (_model == null)
        {
            return;
        }
        else
        {
            _animStates = _model.GetComponent<IAnimationStateMaster>();
            _model.SetOwner(this);
        }
    }
    protected void StoreSelf()
    {
        Game.AddToActiveEntities(this);
    }
    public Vector3 GetSpeed()
    {
        if(_movementMaster != null)
        {
            return _movementMaster.GetSpeed();
        }
        else
        {
            return Vector3.zero;
        }
    }
    public float GetStagger()
    {
        if (_stagger != null)
        {
            return _stagger.GetStagger();
        }
        else
        {
            return 0;
        }
    }
    private void OnEnable()
    {
        Game.AddToActiveEntities(this);
    }
    private void OnDisable()
    {
        Game.RemoveFromActiveEntities(this);
    }
    public bool IsWalking()
    {
        if (_inputReader != null)
        {
            return (_inputReader.GetForwardBackMovement() != 0 || _inputReader.GetLeftRightMovement() != 0);
        }
        else
        {
            return false;
        }
    }
    public void Kill()
    {
        if (!_dead)
        {
            Killed?.Invoke();
            _dead = true;
        }
    }
    public bool IsPlayer()
    {
        return _isPlayer;
    }
    public HealthSystem GetHealthSystem()
    {
        return _healthSystem;
    }
    public CharacterController GetCharacterController()
    {
        return _characterController;
    }
    public bool IsDead()
    {
        return _dead;
    }
    public void SetLastHitbox(Hitbox box)
    {
        _lastHitbox = box;
    }
    public IStaggerSystem GetStaggerSystem()
    {
        return _stagger;
    }
    public IMovementMaster GetMovementSystem()
    {
        return _movementMaster;
    }
    public State GetDefaultState()
    {
        return _defaultState;
    }
    public void ForceState(State state)
    {
        _state = state;
    }
}
