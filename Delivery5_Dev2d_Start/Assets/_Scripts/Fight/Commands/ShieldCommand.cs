using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionFactory
{
    class ShieldCommand : FightCommand
    {
        public ShieldCommand()
        {
            _type = FightCommandTypes.Shield;
            PossibleTargets = TargetTypes.FriendNotSelf;
            hasOneTurnEffect = true;
        }

        public ShieldCommand(Entity actor, Entity target)
        {
            _type = FightCommandTypes.Shield;
            PossibleTargets = TargetTypes.FriendNotSelf;
            hasOneTurnEffect = true;

            ownActor = actor as Fighter;
            targetActor = target as Fighter;
        }

        public override void Excecute()
        {
            targetActor.AddDefense(5);
        }

        public override void Undo()
        {
            targetActor.AddDefense(-5);
        }
    }
}
