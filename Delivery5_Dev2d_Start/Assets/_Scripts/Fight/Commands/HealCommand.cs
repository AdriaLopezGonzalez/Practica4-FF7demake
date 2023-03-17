using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionFactory
{
    class HealCommand : FightCommand
    {
        public HealCommand()
        {
            _type = FightCommandTypes.Heal;
            PossibleTargets = TargetTypes.Friend;
            hasOneTurnEffect = false;
        }

        public HealCommand(Entity actor, Entity target)
        {
            _type = FightCommandTypes.Heal;
            PossibleTargets = TargetTypes.Friend;
            hasOneTurnEffect = false;

            ownActor = actor as Fighter;
            targetActor = target as Fighter;
        }

        public override void Excecute()
        {
            if (!(targetActor.CurrentHealth + 3 > targetActor.MaxHealth))
            {
                targetActor.CurrentHealth += 3;
            }
            else
            {
                targetActor.CurrentHealth = targetActor.MaxHealth;
            }
        }

        public override void Undo()
        {
            targetActor.TakeDamage(3 + targetActor.Defense);
        }
    }
}
