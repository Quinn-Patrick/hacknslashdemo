using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFireball : State
{
    private float _attackTime = 2.0f;
    public StateFireball(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Fireball;
    }

    override public State InterpretInput()
    {
        if (IsDead())
        {
            return new StateDeadPlayer(_input, _self, _model);
        }

        _input.NeutralizeDirectionalInputs();
        _attackTime -= Time.deltaTime;
        if (_attackTime <= 0)
        {
            return new StateStandWizard(_input, _self, _model);
        }

        return this;
    }
}
