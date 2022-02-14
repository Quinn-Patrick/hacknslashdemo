using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateOrbiterDead : State
{
    public StateOrbiterDead(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Dead;
    }

    public override State InterpretInput()
    {
        if(_self is LivingEntity)
        {
            LivingEntity selfImplementation = (LivingEntity)_self;
            selfImplementation.gameObject.SetActive(false);
        }
        return this;
    }
}
