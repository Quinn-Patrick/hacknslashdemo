using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWalkingWizard : State
{
    public StateWalkingWizard(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Walk;
    }

    override public State InterpretInput()
    {
        if (IsDead())
        {
            return new StateDeadPlayer(_input, _self, _model);
        }

        if (Mathf.Abs(_input.GetForwardBackMovement()) < 0.0001 && Mathf.Abs(_input.GetLeftRightMovement()) < 0.0001)
        {
            return new StateStandWizard(_input, _self, _model);
        }

        if (_input.GetAttack())
        {
            return new StateFireball(_input, _self, _model);
        }

        return this;
    }
}
