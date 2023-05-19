namespace MonsterQuest
{
    public class Combat
    {
        public Monster monster { get; private set; }

        public Combat(Monster Monster)
        {
            monster = Monster;
        }
    }
}
