using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class BoostAttackCommand : FightCommand
{
    public BoostAttackCommand()
    {
        _type = FightCommandTypes.BoostAttack;
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
