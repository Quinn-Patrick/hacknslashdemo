using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOrbiterAlive : State
{
    public StateOrbiterAlive(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Stand;
    }

    public override State InterpretInput()
    {
        if (_self.IsDead())
        {
            return new StateOrbiterDead(_input, _self, _model);
        }
        return this;
    }
}
