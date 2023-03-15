using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BoostDefenseCommand : FightCommand
{
    public BoostDefenseCommand()
    {
        _type = FightCommandTypes.BoostDefense;
        PossibleTargets = TargetTypes.Self;
    }

    public override void Excecute()
    {
    }

    public override void Undo()
    {
    }
    // hacer un constructor aqui de fight command
}
