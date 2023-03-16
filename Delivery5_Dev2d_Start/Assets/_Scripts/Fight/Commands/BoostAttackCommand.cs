using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BoostAttackCommand : FightCommand
{
    Fighter ownActor;
    Fighter targetActor;
    public BoostAttackCommand()
    {
        _type = FightCommandTypes.BoostAttack;
        PossibleTargets = TargetTypes.Self;
    }

    public BoostAttackCommand(Entity actor, Entity target)
    {
        _type = FightCommandTypes.BoostAttack;
        PossibleTargets = TargetTypes.Self;
        ownActor = actor as Fighter;
        targetActor = target as Fighter;
    }

    public override void Excecute()
    {
    }

    public override void Undo()
    {
    }
    // hacer un constructor aqui de fight command
}
