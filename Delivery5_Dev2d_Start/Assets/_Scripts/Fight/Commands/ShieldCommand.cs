using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ShieldCommand : FightCommand
{
    Fighter ownActor;
    Fighter targetActor;
    public ShieldCommand()
    {
        _type = FightCommandTypes.Shield;
        PossibleTargets = TargetTypes.FriendNotSelf;
    }

    public ShieldCommand(Entity actor, Entity target)
    {
        _type = FightCommandTypes.Shield;
        PossibleTargets = TargetTypes.FriendNotSelf;
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
