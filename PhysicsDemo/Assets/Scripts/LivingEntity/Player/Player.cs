using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Player : LivingEntity
{
    public ControllableCamera cam;

    public Room roomManager;

    public Vector3 LastPosition;

    private void Awake()
    {
        InitializeComponents();
        _characterController = GetComponent<CharacterController>();
    }
    void Start()
    {
        _defaultState = new StateStandingPlayer(_inputReader, this, _model);
        StoreSelf();
        _isPlayer = true;
        
        Physics.gravity = new Vector3(0, -20.0f, 0);
        _attackHitboxLayer = 3;
        if (_model == null)
        {
            return;
        }
        else
        {
            AnimatedModel modelObject = (AnimatedModel)_model;
            _animStates = modelObject.GetComponent<IAnimationStateMaster>();
        }
    }
    public void Resurrect()
    {
        _dead = false;
    }
    new public ICharacterModel GetModel()
    {
        return _model;
    }
    new public void Kill()
    {
        _dead = true;
        _characterController.enabled = false;
    }
}
