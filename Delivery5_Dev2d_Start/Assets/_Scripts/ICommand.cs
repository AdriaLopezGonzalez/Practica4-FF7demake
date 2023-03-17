using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionFactory
{
    public interface ICommand
    {
        void Excecute();
        void Undo();
    }
}
