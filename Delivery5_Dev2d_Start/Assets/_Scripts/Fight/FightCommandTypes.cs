using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionFactory
{
    public enum FightCommandTypes
    {
        Attack,
        BoostAttack,
        BoostDefense,
        Heal,
        Shield,
        StrongAttack,
    }

    public enum TargetTypes
    {
        Enemy,
        Friend,
        Self,
        FriendNotSelf,

    }
}