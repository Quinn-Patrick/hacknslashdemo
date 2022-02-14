using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStandWizard : State
{
    public StateStandWizard(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Stand;
    }

    public override State InterpretInput()
    {

        if (IsDead())
        {
            return new StateDeadPlayer(_input, _self, _model);
        }

        if (_input == null) return this;

        if (Mathf.Abs(_input.GetForwardBackMovement()) > 0.0001 || Mathf.Abs(_input.GetLeftRightMovement()) > 0.0001)
        {
            return new StateWalkingWizard(_input, _self, _model);
        }

        if (_input.GetAttack())
        {
            return new StateFireball(_input, _self, _model);
        }

        return this;
    }
}
