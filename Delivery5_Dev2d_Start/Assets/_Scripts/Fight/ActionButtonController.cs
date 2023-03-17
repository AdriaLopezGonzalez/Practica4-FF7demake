using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReflectionFactory
{
    public class ActionButtonController : MonoBehaviour
    {
        // public Color[] Colors;
        public ActionButton ActionButtonPrefab;

        public List<FightCommandTypes> PossibleCommands;

        public CombatManager CombatManager;

        private List<GameObject> CurrentButtons = new List<GameObject>();

        public CanvasGroup _canvasGroup;

        //public CubeColor Cube;

        // Start is called before the first frame update
        //void Awake()
        //{
        //    _canvasGroup = GetComponent<CanvasGroup>();
        //}


        public void SetFighterButtons(Fighter currentFighter)
        {
            foreach (GameObject b in CurrentButtons)
            {
                Destroy(b);
            }
            CurrentButtons.Clear();

            PossibleCommands = currentFighter.PossibleCommands;

            for (int i = 0; i < PossibleCommands.Count; i++)
            {
                ActionButton button = Instantiate(ActionButtonPrefab);
                button.Init(PossibleCommands[i], this);
                button.transform.SetParent(_canvasGroup.transform);
                CurrentButtons.Add(button.gameObject);
            }

            Show();
        }

        internal void ChooseTarget(Entity activeEntity)
        {
            Hide();
        }

        void Show()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }

        void Hide()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }






        public void OnButtonPressed(FightCommandTypes fightCommandType)
        {
            CombatManager.DoAction(fightCommandType);
        }
    }
}
