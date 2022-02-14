using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateSlash2 : State
{
    private float _attackTime = 0.5f;
    private IFacesTarget _faceTarget;
    public StateSlash2(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Slash2;
        if(_self is LivingEntity)
        {
            _faceTarget = ((LivingEntity)_self).GetComponent<IFacesTarget>();
        }
        if (_faceTarget == null) return;
        _faceTarget.FaceTarget(_model);
    }

    override public State InterpretInput()
    {
        if (_self is Player) SetAnimationStates();
        if (IsDead())
        {
            return new StateDeadPlayer(_input, _self, _model);
        }

        _input.NeutralizeDirectionalInputs();
        _attackTime -= Time.deltaTime;
        if (_attackTime <= 0)
        {
            return new StateStandingPlayer(_input, _self, _model);
        }

        if (_input.GetAttack())
        {
            if (_attackTime < 0.2f)
            {
                return new StateSpinAttack(_input, _self, _model);
            }

        }

        return this;
    }

    private void SetAnimationStates()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("GreatswordAttacks"), 1);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Greatsword"), 0);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Base Layer"), 0);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Stagger"), 0);
    }
}
