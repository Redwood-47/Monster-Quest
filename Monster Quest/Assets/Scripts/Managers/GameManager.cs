using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonsterQuest
{
    public class GameManager : MonoBehaviour
    {
        private CombatManager combatManager;
        private CombatPresenter combatPresenter;
        private GameState gameState;
        [SerializeField] private Sprite[] characterSprite;
        [SerializeField] private Sprite[] monsterSprite;

        private void Awake()
        {
            combatManager = GetComponent<CombatManager>();
            combatPresenter = GetComponentInChildren<CombatPresenter>();
        }
        // Start is called before the first frame update
        IEnumerator Start()
        {
            NewGame();
            yield return Simulate();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void NewGame()
        {
            Party party = new Party(new List<Character>());
            gameState = new GameState(party);

            gameState.party.characters.Add(new Character("Salty Roger", characterSprite[0], 10, SizeCategory.Medium));
            gameState.party.characters.Add(new Character("Foul Fritjof", characterSprite[1], 10, SizeCategory.Medium));
            gameState.party.characters.Add(new Character("Captain Hector Barbossa", characterSprite[2], 10, SizeCategory.Medium));
            gameState.party.characters.Add(new Character("Captain Sinclair", characterSprite[3], 10, SizeCategory.Medium));
        }

        public IEnumerator Simulate()
        {
            Debug.Log("Hi");
            combatPresenter.InitializeParty(gameState);

            Console.WriteLine($"Swashbuckling pirates {StringHelper.JoinWithAnd(gameState.party.characters)} stand upon the deck.");

            int skeletonHP = DiceHelper.Roll("2d8+6");
            gameState.EnterCombatWithMonster(new Monster("Agile Shark", monsterSprite[0], skeletonHP, SizeCategory.Medium, 10));
            combatPresenter.InitializeMonster(gameState);
            yield return combatManager.Simulate(gameState);

            int sahuaginHp = DiceHelper.Roll("6d8+12");
            gameState.EnterCombatWithMonster(new Monster("Giant Crab", monsterSprite[1], sahuaginHp, SizeCategory.Medium, 18));
            combatPresenter.InitializeMonster(gameState);
            yield return combatManager.Simulate(gameState);

            int krakenHp = DiceHelper.Roll("12d10+40");
            gameState.EnterCombatWithMonster(new Monster("Mighty Dragon Turtle", monsterSprite[2], krakenHp, SizeCategory.Gargantuan, 16));
            combatPresenter.InitializeMonster(gameState);
            yield return combatManager.Simulate(gameState);

            if (gameState.party.characters.Count > 0)
            {
                Console.WriteLine($"After defending their ship from three vicious attackers, the pirates {StringHelper.JoinWithAnd(gameState.party.characters)} sail away to plunder another day.");
            }
        }
    }
}
