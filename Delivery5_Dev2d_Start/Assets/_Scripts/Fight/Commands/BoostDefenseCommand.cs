using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionFactory
{
    class BoostDefenseCommand : FightCommand
    {
        public BoostDefenseCommand()
        {
            _type = FightCommandTypes.BoostDefense;
            PossibleTargets = TargetTypes.Self;
            hasOneTurnEffect = false;
        }

        public BoostDefenseCommand(Entity actor, Entity target)
        {
            _type = FightCommandTypes.BoostDefense;
            PossibleTargets = TargetTypes.Self;
            hasOneTurnEffect = false;

            ownActor = actor as Fighter;
            targetActor = target as Fighter;
        }

        public override void Excecute()
        {
            targetActor.AddDefensePermanent(1);
        }

        public override void Undo()
        {
            targetActor.AddDefensePermanent(-1);
        }

    }
}
