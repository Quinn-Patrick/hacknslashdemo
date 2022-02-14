using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateInAirPlayer : State
{
    public StateInAirPlayer(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.InAir;
    }

    override public State InterpretInput()
    {
        if (_self is Player) SetAnimationStates();
        if (_self.GetCharacterController().isGrounded)
        {
            return new StateStandingPlayer(_input, _self, _model);
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
