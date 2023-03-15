﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public EntityManager EntityManager;
    public ActionButtonController ActionButtonController;
    public ChooseTarget TargetChooser;
    public Invoker Invoker;
    public StatsUI Stats;

    

    // Start is called before the first frame update
    void Start()
    {
        //_factory = new CommandFactory();
        StartBattle();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            Undo();
    }

    void StartBattle()
    {
        Fighter currentFighter = EntityManager.ActiveEntity as Fighter;
        Stats.SetEntity(currentFighter);
        ActionButtonController.SetFighterButtons(currentFighter);
    }

    public void DoAction(FightCommandTypes commandType)
    {
        Fighter ActionDoer = EntityManager.ActiveEntity as Fighter;
        //DENTRO SWITCH
        FightCommand doingCommand = null;

        switch (commandType)
        {
            case FightCommandTypes.Attack:
                doingCommand = new AttackCommand();
                break;
            case FightCommandTypes.BoostAttack:
                doingCommand = new BoostAttackCommand();
                break;
            case FightCommandTypes.BoostDefense:
                doingCommand = new BoostDefenseCommand();
                break;
            case FightCommandTypes.Heal:
                doingCommand = new HealCommand();
                break;
            case FightCommandTypes.Shield:
                doingCommand = new ShieldCommand();
                break;
        }
        ChooseTarget(doingCommand);
        /*foreach (FightCommand c in ActionDoer.PossibleCommands)
        {

        }

        if (commandType == FightCommandTypes.Attack)
        {
            ChooseTarget(AttackCommand as FightCommand);
        }
        */
        //ChooseTarget(manera de conectar command type con fight commands);

    }
    
    private void ChooseTarget(FightCommand _currentCommand)
    {
        var targetTypes = _currentCommand.PossibleTargets;

        Entity[] possibleTargets;

        switch (targetTypes)
        {
            case TargetTypes.Enemy:
                possibleTargets = EntityManager.Enemies;
                break;
            case TargetTypes.Friend:
                possibleTargets = EntityManager.Friends;
                break;
            case TargetTypes.FriendNotSelf:
                possibleTargets = EntityManager.FriendsNotSelf;
                break;
            case TargetTypes.Self:
                possibleTargets = new Entity[1];
                possibleTargets[0] = EntityManager.ActiveEntity;
                break;

            default:
                possibleTargets = EntityManager.Enemies;
                break;
        }
        ActionButtonController.ChooseTarget(EntityManager.ActiveEntity);
        TargetChooser.StartChoose(possibleTargets);
    }
    
    private void DoAction(Entity actor, Entity target, FightCommandTypes type)
    {
        
    }

    private void Undo()
    {
        
    }


    public void NextTurn()
    {
        
    }

    internal void TargetChosen(ISelectable entity)
    {
        if(!(entity is Entity))
        {
            Debug.LogError("Selected is not entity");
            return;
        }
     
    }
}
