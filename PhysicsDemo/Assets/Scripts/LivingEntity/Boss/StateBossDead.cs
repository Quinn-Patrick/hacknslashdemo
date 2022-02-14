using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBossDead : State
{
    private IBouncingEntity _boss;

    public StateBossDead(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Dead;
        if (_self is IBouncingEntity)
        {
            _boss = (IBouncingEntity)_self;
            if (_boss is Boss)
            {
                Boss specificBoss = (Boss)_boss;
                specificBoss.GetMovementSystem().GetSpeedSystem().SetBaseSpeed(0f);
            }
        }
        else _boss = null;
    }

    public override State InterpretInput()
    {
        return this;
    }

    new public State ForceStaggerState(float stagger)
    {
        return this;
    }
}
