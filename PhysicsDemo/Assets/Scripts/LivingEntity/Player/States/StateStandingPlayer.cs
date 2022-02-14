using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStandingPlayer : State
{
    public StateStandingPlayer(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Stand;
    }

    override public State InterpretInput()
    {
        if (_self is Player) SetAnimationStates();

        if (IsDead())
        {
            return new StateDeadPlayer(_input, _self, _model);
        }

        if (_input == null) return this;

        if(Mathf.Abs(_input.GetForwardBackMovement()) > 0.0001 || Mathf.Abs(_input.GetLeftRightMovement()) > 0.0001)
        {
            return new StateWalking(_input, _self, _model);
        }

        if (_input.GetAttack())
        {
            return new StateSlash1(_input, _self, _model);
        }

        return this;
    }

    private void SetAnimationStates()
    {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex("GreatswordAttacks")) > 0)
        {
            _animator.SetLayerWeight(_animator.GetLayerIndex("GreatswordAttacks"), _animator.GetLayerWeight(_animator.GetLayerIndex("GreatswordAttacks")) - 3 * Time.deltaTime);
        }
        if (_animator.GetLayerWeight(_animator.GetLayerIndex("Greatsword")) < 1)
        {
            _animator.SetLayerWeight(_animator.GetLayerIndex("Greatsword"), _animator.GetLayerWeight(_animator.GetLayerIndex("Greatsword")) + 3 * Time.deltaTime);
        }
        if (_animator.GetLayerWeight(_animator.GetLayerIndex("Base Layer")) < 1)
        {
            _animator.SetLayerWeight(_animator.GetLayerIndex("Base Layer"), _animator.GetLayerWeight(_animator.GetLayerIndex("Base Layer")) + 3 * Time.deltaTime);
        }

        _animator.SetLayerWeight(_animator.GetLayerIndex("Stagger"), 0);
    }
}
