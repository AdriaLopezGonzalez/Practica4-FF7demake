using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class ShieldCommand : FightCommand
{
    public ShieldCommand()
    {
        _type = FightCommandTypes.Shield;
        PossibleTargets = TargetTypes.FriendNotSelf;
    }

    public override void Excecute()
    {
    }

    public override void Undo()
    {
    }
    // hacer un constructor aqui de fight command
}
