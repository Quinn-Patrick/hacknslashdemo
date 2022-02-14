using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBossPhase2 : State
{
    private IBouncingEntity _boss;

    public StateBossPhase2(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Stand;
        if (_self is IBouncingEntity)
        {
            _boss = (IBouncingEntity)_self;
            if(_boss is Boss)
            {
                Boss specificBoss = (Boss)_boss;
                specificBoss.GetMovementSystem().GetSpeedSystem().SetBaseSpeed(7f);
                specificBoss.GetComponent<SphereCollider>().radius = 0;
                specificBoss.gameObject.layer = 10;
            }
        }
        else _boss = null;
    }

    public override State InterpretInput()
    {
        if (IsDead())
        {
            return new StateBossDead(_input, _self, _model);
        }
        return this;
    }

    new public State ForceStaggerState(float stagger)
    {
        return this;
    }
}
