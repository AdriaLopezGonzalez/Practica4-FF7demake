using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionFactory
{
    public abstract class FightCommand : ICommand
    {
        public TargetTypes PossibleTargets;
        public FightCommandTypes _type;

        public Fighter ownActor;
        public Fighter targetActor;

        public bool hasOneTurnEffect;

        public FightCommand() { }

        public abstract void Excecute();

        public abstract void Undo();

    }
}