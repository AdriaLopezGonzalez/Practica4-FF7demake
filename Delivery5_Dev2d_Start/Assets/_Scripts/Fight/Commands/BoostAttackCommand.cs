using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionFactory
{
    class BoostAttackCommand : FightCommand
    {
        public BoostAttackCommand()
        {
            _type = FightCommandTypes.BoostAttack;
            PossibleTargets = TargetTypes.Self;
            hasOneTurnEffect = false;
        }

        public BoostAttackCommand(Entity actor, Entity target)
        {
            _type = FightCommandTypes.BoostAttack;
            PossibleTargets = TargetTypes.Self;
            hasOneTurnEffect = false;

            ownActor = actor as Fighter;
            targetActor = target as Fighter;
        }

        public override void Excecute()
        {
            targetActor.AddAttackPermanent(1);
        }

        public override void Undo()
        {
            targetActor.AddAttackPermanent(-1);
        }

    }
}
