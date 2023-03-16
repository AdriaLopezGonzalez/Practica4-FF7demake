using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BoostDefenseCommand : FightCommand
{
    Fighter ownActor;
    Fighter targetActor;
    public BoostDefenseCommand()
    {
        _type = FightCommandTypes.BoostDefense;
        PossibleTargets = TargetTypes.Self;
    }

    public BoostDefenseCommand(Entity actor, Entity target)
    {
        _type = FightCommandTypes.BoostDefense;
        PossibleTargets = TargetTypes.Self;
        ownActor = actor as Fighter;
        targetActor = target as Fighter;
    }

    public override void Excecute()
    {
        targetActor.AddDefensePermanent(1);
    }

    public override void Undo()
    {
    }
    // hacer un constructor aqui de fight command
}
