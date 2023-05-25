using UnityEngine;

namespace MonsterQuest
{
    public class Monster : Creature
    {

        public int savingThrowDC { get; private set; }


        public Monster(string displayName, Sprite bodySprite, int hitPointsMaximum, SizeCategory sizeCategory, int SavingThrowDC) : base(displayName, bodySprite, hitPointsMaximum, sizeCategory)
        {
            this.savingThrowDC = SavingThrowDC;
        }

    }
}
