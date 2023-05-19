using System;

namespace MonsterQuest
{
    public class Monster
    {
        public string displayName { get; private set; }
        public int hitPoints { get; private set; }
        public int savingThrowDC { get; private set; }


        public Monster(string DisplayName, int HitPoints, int SavingThrowDC)
        {
            displayName = DisplayName;
            hitPoints = HitPoints;
            savingThrowDC = SavingThrowDC;
        }

        public void ReactToDamage(int DamageAmount)
        {
            hitPoints = Math.Max(0, hitPoints - DamageAmount);
        }
    }
}
