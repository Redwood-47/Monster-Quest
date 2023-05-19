namespace MonsterQuest
{
    public class Character
    {
        public string displayName { get; private set; }

        public Character(string DisplayName)
        {
            displayName = DisplayName;
        }
    }
}
