using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStagger : State
{
    private float _staggerTime = 0;
    public StateStagger(InputReader input, ILivingEntity self, ICharacterModel model, float stagger) : base(input, self, model)
    {
        _state = StateNumber.Stagger;
        _staggerTime = stagger;
    }

    public override State InterpretInput()
    {
        if (_self is Player) SetAnimationStates();
        if (IsDead())
        {
            return new StateDeadPlayer(_input, _self, _model);
        }

        _staggerTime -= Time.deltaTime;
        if(_staggerTime <= 0)
        {
            return _self.GetDefaultState();
        }
        return this;
    }

    private void SetAnimationStates()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Stagger"), 1);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Greatsword"), 0);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Base Layer"), 0);
        _animator.SetLayerWeight(_animator.GetLayerIndex("GreatswordAttacks"), 0);
    }
}
