using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class HealCommand : FightCommand
{
    Fighter ownActor;
    Fighter targetActor;
    public HealCommand()
    {
        _type = FightCommandTypes.Heal;
        PossibleTargets = TargetTypes.Friend;
    }

    public HealCommand(Entity actor, Entity target)
    {
        _type = FightCommandTypes.Heal;
        PossibleTargets = TargetTypes.Friend;
        ownActor = actor as Fighter;
        targetActor = target as Fighter;
    }

    public override void Excecute()
    {
        if(!(targetActor.CurrentHealth + 3 > targetActor.MaxHealth))
        {

        }
    }

    public override void Undo()
    {
    }
    // hacer un constructor aqui de fight command
}
