using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


class AttackCommand : FightCommand
{
    Fighter ownActor;
    Fighter targetActor;

    public AttackCommand()
    {
        _type = FightCommandTypes.Attack;
        PossibleTargets = TargetTypes.Enemy;
    }
    public AttackCommand(Entity actor, Entity target)
    {
        _type = FightCommandTypes.Attack;
        PossibleTargets = TargetTypes.Enemy;
        ownActor = actor as Fighter;
        targetActor = target as Fighter;
    }

    public override void Excecute()
    {
        targetActor.TakeDamage(ownActor.Attack);
    }

    public override void Undo()
    {
        if (!(targetActor.CurrentHealth + (ownActor.Attack - targetActor.Defense) > targetActor.MaxHealth))
        {
            targetActor.CurrentHealth += (ownActor.Attack - targetActor.Defense);
        }
        else
        {
            targetActor.CurrentHealth = targetActor.MaxHealth;
        }

        Debug.Log(targetActor.name + " Life: " + targetActor.CurrentHealth);

    }
}
