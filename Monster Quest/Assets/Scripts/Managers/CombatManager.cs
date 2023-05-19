using UnityEngine;

namespace MonsterQuest
{
    public class CombatManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Simulate(GameState gameState)
        {
            if (gameState.party.characters.Count == 0)
            {
                return;
            }
            Console.WriteLine($"A mighty {gameState.combat.monster.displayName} with {gameState.combat.monster.hitPoints} HP heaves itself upon the deck of the ship!");
            do
            {
                foreach (Character pirate in gameState.party.characters)
                {
                    int boatAxeTotal = DiceHelper.Roll("2d6");
                    Monster monster = gameState.combat.monster;
                    monster.ReactToDamage(boatAxeTotal);

                    Console.WriteLine(" ");
                    Console.WriteLine($"{pirate.displayName} slashes the {gameState.combat.monster.displayName} for {boatAxeTotal} damage. The {gameState.combat.monster.displayName} has {gameState.combat.monster.hitPoints} HP left.");

                    if (gameState.combat.monster.hitPoints == 0)
                    {
                        Console.WriteLine($"The {gameState.combat.monster.displayName} slumps back into the ocean, defeated. Our pirates celebrate with a crate of rum!");
                        break;
                    }
                }
                if (gameState.combat.monster.hitPoints > 0)
                {
                    if (gameState.party.characters.Count == 0)
                    {
                        Console.WriteLine($"The {gameState.combat.monster.displayName} has defeated our swasbuckling heroes!");
                        break;
                    }
                    int target = UnityEngine.Random.Range(0, gameState.party.characters.Count);
                    Console.WriteLine("");
                    Console.WriteLine($"The {gameState.combat.monster.displayName} attacks {gameState.party.characters[target].displayName}!");
                    int dexSavingthrow = DiceHelper.Roll("1d20+3");
                    Console.Write($"{gameState.party.characters[target].displayName} rolls a {dexSavingthrow} Saving Throw,");

                    if (dexSavingthrow < gameState.combat.monster.savingThrowDC)
                    {
                        gameState.party.characters.RemoveAt(target);
                        Console.Write(" fails the Saving Throw and has met their demise!");
                        Console.WriteLine(" ");
                    }

                    else
                    {
                        Console.Write(" succeeds the Saving Throw and manages to keep fighting!");
                        Console.WriteLine("");
                    }
                }
            } while (gameState.combat.monster.hitPoints > 0);
        }
    }
}
