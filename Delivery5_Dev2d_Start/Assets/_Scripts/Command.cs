using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionFactory
{
    public abstract class Command : ICommand
    {
        protected Entity _entity;

        protected Command(Entity entity)
        {
            _entity = entity;
        }

        public abstract void Excecute();
        public abstract void Undo();
    }
}
