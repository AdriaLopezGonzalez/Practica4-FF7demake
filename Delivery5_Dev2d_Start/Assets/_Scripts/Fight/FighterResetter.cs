using UnityEngine;

namespace ReflectionFactory
{
    public class FighterResetter : MonoBehaviour
    {
        private Fighter[] FightersToReset = new Fighter[4];
        public EntityManager EntityManager;
        private int TurnNum;

        private void Start()
        {
            FightersToReset[TurnNum] = null;
        }

        public void AddReset(Fighter newFighter)
        {
            FightersToReset[TurnNum] = newFighter;
        }

        public void CheckReset()
        {
            Debug.Log("El turno ahora es: " + TurnNum);
            if (FightersToReset[TurnNum])
            {
                FightersToReset[TurnNum].ResetFighter();
                Debug.Log(FightersToReset[TurnNum].name + " has been resetted");
                FightersToReset[TurnNum] = null;
            }
        }

        public void NextTurn()
        {
            if (TurnNum == 3)
            {
                TurnNum = 0;
            }
            else
            {
                TurnNum++;
            }
        }
    }
}
