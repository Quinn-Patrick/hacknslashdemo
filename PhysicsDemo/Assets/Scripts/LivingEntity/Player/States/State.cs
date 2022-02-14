using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected InputReader _input;
    protected ILivingEntity _self;
    protected ICharacterModel _model;
    protected StateNumber _state;
    protected HealthSystem _health;

    protected Animator _animator;
    public State(InputReader input, ILivingEntity self, ICharacterModel model)
    {
        _input = input;
        _self = self;
        _model = model;
        _health = _self.GetHealthSystem();
        if (_model == null) return;
        _animator = _model.GetAnimator();
    }

    public abstract State InterpretInput();

    public StateNumber GetStateNumber()
    {
        return _state;
    }

    public State ForceStaggerState(float stagger)
    {
        return new StateStagger(_input, _self, _model, stagger);
    }

    protected bool IsDead()
    {
        if (_health == null) return false;

        if(_health.GetCurrentHealth() <= 0)
        {
            return true;
        }
        return false;
    }
}
