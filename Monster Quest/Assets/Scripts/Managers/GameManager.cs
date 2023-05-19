using System.Collections.Generic;
using UnityEngine;

namespace MonsterQuest
{
    public class GameManager : MonoBehaviour
    {
        private CombatManager combatManager;
        private GameState gameState;

        private void Awake()
        {
            combatManager = GetComponent<CombatManager>();
        }
        // Start is called before the first frame update
        void Start()
        {
            NewGame();
            Simulate();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void NewGame()
        {
            Party party = new Party(new List<Character>());
            gameState = new GameState(party);
        }

        public void Simulate()
        {
            gameState.party.characters.Add(new Character("David"));
            gameState.party.characters.Add(new Character("Foul Fritjof"));
            gameState.party.characters.Add(new Character("Rozanna"));
            gameState.party.characters.Add(new Character("Sinclair"));

            Console.WriteLine($"Swashbuckling pirates {StringHelper.JoinWithAnd(gameState.party.characters)} stand upon the deck.");

            int skeletonHP = DiceHelper.Roll("2d8+6");
            gameState.EnterCombatWithMonster(new Monster("Drowned Skeleton", skeletonHP, 10));
            combatManager.Simulate(gameState);

            int sahuaginHp = DiceHelper.Roll("6d8+12");
            gameState.EnterCombatWithMonster(new Monster("Sahuagin", sahuaginHp, 18));
            combatManager.Simulate(gameState);

            int krakenHp = DiceHelper.Roll("8d10+40");
            gameState.EnterCombatWithMonster(new Monster("Kraken", krakenHp, 16));
            combatManager.Simulate(gameState);

            if (gameState.party.characters.Count > 0)
            {
                Console.WriteLine($"After defending their ship from three vicious attackers, the pirates {StringHelper.JoinWithAnd(gameState.party.characters)} sail away to plunder another day.");
            }
        }
    }
}
