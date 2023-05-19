using System.Collections.Generic;

namespace MonsterQuest
{
    public class Party
    {
        public List<Character> characters { get; private set; }

        public Party(IEnumerable<Character> initialCharacters)
        {
            characters = new List<Character>(initialCharacters);
        }
    }
}
