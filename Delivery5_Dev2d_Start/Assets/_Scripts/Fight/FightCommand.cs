using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class FightCommand : ICommand
{
    public TargetTypes PossibleTargets;
    public FightCommandTypes _type;

    public virtual void Excecute()
    {
    }

    public virtual void Undo()
    {
    }
}