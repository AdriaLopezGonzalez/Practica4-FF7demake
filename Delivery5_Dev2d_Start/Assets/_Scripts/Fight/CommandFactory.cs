using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace ReflectionFactory
{
    public class CommandFactory
    {
        private Dictionary<FightCommandTypes, Type> _weaponsByName;

        public CommandFactory()
        {
            var weaponTypes = Assembly.GetAssembly(typeof(FightCommand)).GetTypes()
                .Where(x => !x.IsAbstract && typeof(FightCommand).IsAssignableFrom(x));

            _weaponsByName = new Dictionary<FightCommandTypes, Type>();

            foreach (var type in weaponTypes)
            {
                var tempWeapon = Activator.CreateInstance(type);
                _weaponsByName.Add(((FightCommand)tempWeapon)._type, type);
            }

        }

        public FightCommand GetCommand(FightCommandTypes commandType)
        {
            if (_weaponsByName.ContainsKey(commandType))
            {
                return Activator.CreateInstance(_weaponsByName[commandType]) as FightCommand;
            }
            return null;
        }

        public FightCommand GetCommand(Entity actor, Entity target, FightCommandTypes commandType)
        {
            if (_weaponsByName.ContainsKey(commandType))
            {
                Entity[] objParameters = new Entity[2];
                objParameters[0] = actor;
                objParameters[1] = target;
                return Activator.CreateInstance(_weaponsByName[commandType], objParameters) as FightCommand;
            }
            return null;
        }

        public FightCommandTypes[] GetNames()
        {
            return _weaponsByName.Keys.ToArray();
        }
    }
}
