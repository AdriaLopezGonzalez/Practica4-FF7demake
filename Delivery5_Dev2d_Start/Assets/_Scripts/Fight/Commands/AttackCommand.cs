using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


class AttackCommand : FightCommand
{
    public AttackCommand()
    {
        _type = FightCommandTypes.Attack;
        PossibleTargets = TargetTypes.Enemy;
    }

    public override void Excecute()
    {
        Debug.Log("PITOOOOOO");
    }

    public override void Undo()
    {
    }
    // hacer un constructor aqui de fight command
}
