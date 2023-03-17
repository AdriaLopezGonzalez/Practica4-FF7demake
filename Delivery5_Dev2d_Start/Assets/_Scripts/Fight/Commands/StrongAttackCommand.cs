using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ReflectionFactory
{
    class StrongAttackCommand : FightCommand
    {
        public StrongAttackCommand()
        {
            _type = FightCommandTypes.StrongAttack;
            PossibleTargets = TargetTypes.Enemy;
        }
        public StrongAttackCommand(Entity actor, Entity target)
        {
            _type = FightCommandTypes.StrongAttack;
            PossibleTargets = TargetTypes.Enemy;
            hasOneTurnEffect = false;

            ownActor = actor as Fighter;
            targetActor = target as Fighter;
        }

        public override void Excecute()
        {
            targetActor.TakeDamage(ownActor.Attack*5);
        }

        public override void Undo()
        {
            if (!(targetActor.CurrentHealth + ((ownActor.Attack*5) - targetActor.Defense) > targetActor.MaxHealth))
            {
                targetActor.CurrentHealth += ((ownActor.Attack*5) - targetActor.Defense);
            }
            else
            {
                targetActor.CurrentHealth = targetActor.MaxHealth;
            }

            Debug.Log(targetActor.name + " Life: " + targetActor.CurrentHealth);

        }
    }
}
