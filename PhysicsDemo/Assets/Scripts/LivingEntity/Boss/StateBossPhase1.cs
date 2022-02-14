using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBossPhase1 : State
{
    private IBouncingEntity _boss;
    
    public StateBossPhase1(InputReader input, ILivingEntity self, ICharacterModel model) : base(input, self, model)
    {
        _state = StateNumber.Stand;
        if (_self is IBouncingEntity) _boss = (IBouncingEntity)_self;
        else _boss = null;
    }
    public override State InterpretInput()
    {
        if (_boss == null) return this;
        List<Orbiter> orbiters = _boss.GetOrbiters();
        if (AllOrbitersDead(orbiters))
        {
            return new StateBossPhase2(_input, _self, _model);
        }
        return this;
    }
    new public State ForceStaggerState(float stagger)
    {
        return this;
    }

    private bool AllOrbitersDead(List<Orbiter> orbiters)
    {
        bool allDead = true;
        foreach(Orbiter o in orbiters)
        {
            if (!o.IsDead())
            {
                allDead = false;
            }
        }
        return allDead;
    }
}
