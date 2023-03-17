using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ReflectionFactory
{
    class AttackCommand : FightCommand
    {
        public AttackCommand()
        {
            _type = FightCommandTypes.Attack;
            PossibleTargets = TargetTypes.Enemy;
            hasOneTurnEffect = false;
        }
        public AttackCommand(Entity actor, Entity target)
        {
            _type = FightCommandTypes.Attack;
            PossibleTargets = TargetTypes.Enemy;
            hasOneTurnEffect = false;

            ownActor = actor as Fighter;
            targetActor = target as Fighter;
        }

        public override void Excecute()
        {
            targetActor.TakeDamage(ownActor.Attack);
        }

        public override void Undo()
        {

            targetActor.CurrentHealth += (ownActor.Attack - targetActor.Defense);

            Debug.Log(targetActor.name + " Life: " + targetActor.CurrentHealth);

        }
    }
}
