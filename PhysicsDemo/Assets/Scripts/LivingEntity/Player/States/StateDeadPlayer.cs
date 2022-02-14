using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateDeadPlayer : State
{
    public StateDeadPlayer(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Dead;
    }

    public override State InterpretInput()
    {
        if (_self is Player) SetAnimationStates();
        return this;
    }

    private void SetAnimationStates()
    {
        _animator.SetLayerWeight(_animator.GetLayerIndex("Greatsword"), 0);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Stagger"), 0);
        _animator.SetLayerWeight(_animator.GetLayerIndex("GreatswordAttacks"), 0);
        _animator.SetLayerWeight(_animator.GetLayerIndex("Base Layer"), 1);
    }
}
