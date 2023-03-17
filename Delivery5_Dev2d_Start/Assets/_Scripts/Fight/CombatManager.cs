using UnityEngine;

namespace ReflectionFactory
{
    public class CombatManager : MonoBehaviour
    {
        public EntityManager EntityManager;
        public ActionButtonController ActionButtonController;
        public ChooseTarget TargetChooser;
        public Invoker Invoker;
        public StatsUI Stats;
        private CommandFactory _factory;
        public FighterResetter FighterResetter;

        private FightCommandTypes currentCommandType;

        // Start is called before the first frame update
        void Awake()
        {
            _factory = new CommandFactory();
            StartBattle();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
                Undo();
        }

        void StartBattle()
        {
            SetFighter();
        }

        public void DoAction(FightCommandTypes commandType)
        {
            
            var thisCommand = _factory.GetCommand(commandType);
            currentCommandType = thisCommand._type;
            ChooseTarget(thisCommand);

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
            var currentCommand = _factory.GetCommand(actor, target, type);
            if (currentCommand.hasOneTurnEffect)
            {
                FighterResetter.AddReset(target as Fighter);
            }
            Invoker.AddCommand(currentCommand);
            NextTurn();

        }

        private void Undo()
        {
            if (Invoker.CanUndo())
            {
                Invoker.Undo();
                EntityManager.SetPreviousEntity();
                SetFighter();
            }
        }


        public void NextTurn()
        {
            EntityManager.SetNextEntity();
            SetFighter();
        }

        internal void TargetChosen(ISelectable entity)
        {
            if (!(entity is Entity))
            {
                Debug.LogError("Selected is not entity");
                return;
            }
            else
            {
                DoAction(EntityManager.ActiveEntity, entity as Entity, currentCommandType);
            }

        }

        private void SetFighter()
        {
            Fighter currentFighter = EntityManager.ActiveEntity as Fighter;
            Stats.SetEntity(currentFighter);
            ActionButtonController.SetFighterButtons(currentFighter);

            FighterResetter.NextTurn();
            FighterResetter.CheckReset();
        }
    }
}
