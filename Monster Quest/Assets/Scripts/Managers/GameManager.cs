using UnityEngine;

namespace MonsterQuest
{
    public class GameManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (IsStandardDiceNotation("3d4") == true)
            {
                Debug.Log(DiceRoll("3d4"));
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

        static int DiceRoll(int numberOfRolls, int diceSides, int fixedBonus = 0)
        {
            int result = 0;
            for (int i = 0; i < numberOfRolls; i++)
            {
                int roll = Random.Range(0, diceSides) + 1;
                result += roll;
            }
            result += fixedBonus;
            return result;
        }

        static int DiceRoll(string DiceNotation)
        {
            DiceNotation.Split("D");
            DiceNotation.Split("+");

            string[] RollStorage = DiceNotation.Split();
            string[] RollStorage2 = DiceNotation.Split();
            string[] RollStorage3 = DiceNotation.Split();
            RollStorage = DiceNotation.Split("d");
            RollStorage2 = RollStorage[1].Split("+");
            RollStorage3 = RollStorage2[0].Split("-");

            int numberOfRolls;
            int diceSides = int.Parse(RollStorage3[0]);
            int fixedBonus;

            if (RollStorage[0] == string.Empty)
            {
                numberOfRolls = 1;
            }
            else
            {
                numberOfRolls = int.Parse(RollStorage[0]);
            }

            if (RollStorage2.Length == 1 && RollStorage3.Length == 1)
            {
                fixedBonus = 0;
            }
            else if (RollStorage3.Length == 2)
            {
                fixedBonus = -int.Parse(RollStorage3[1]);
            }
            else
            {
                fixedBonus = int.Parse(RollStorage2[1]);
            }

            return DiceRoll(numberOfRolls, diceSides, fixedBonus);
        }

        static bool IsStandardDiceNotation(string text)
        {
            if (text.Contains("d"))
            {
                return true;
            }
            else
            {
                Console.WriteLine("Impossible. This is not how you throw a dice. Check your spelling, and try another time.");
                return false;
            }
        }
    }
}
