using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCommand : FightCommand
{
    public HealCommand()
    {
        _type = FightCommandTypes.Heal;
        PossibleTargets = TargetTypes.Friend;
    }

    public override void Excecute()
    {
    }

    public override void Undo()
    {
    }
    // hacer un constructor aqui de fight command
}
