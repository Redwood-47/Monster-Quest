namespace MonsterQuest
{
    public class GameState
    {
        public Party party { get; private set; }
        public Combat combat { get; private set; }

        public GameState(Party Party)
        {
            party = Party;
        }

        public void EnterCombatWithMonster(Monster monster)
        {
            combat = new Combat(monster);
        }
    }
}
