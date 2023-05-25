using System;
using System.Collections;
using UnityEngine;

namespace MonsterQuest
{
    public class Creature
    {
        public CreaturePresenter presenter { get; private set; }

        public string displayName { get; protected set; }

        public Sprite bodySprite { get; protected set; }

        public int hitPointsMaximum { get; protected set; }

        public int hitPoints { get; protected set; }

        public SizeCategory sizeCategory { get; protected set; }

        public float SpaceInFeet
        {
            get
            {
                return SizeHelper.spaceInFeetPerSizeCategory[sizeCategory];
            }
        }

        public Creature(string displayName, Sprite bodySprite, int hitPointsMaximum, SizeCategory sizeCategory)
        {
            this.hitPoints = hitPointsMaximum;
            this.hitPointsMaximum = hitPointsMaximum;
            this.displayName = displayName;
            this.bodySprite = bodySprite;
            this.sizeCategory = sizeCategory;
        }

        public void InitializePresenter(CreaturePresenter presenter)
        {
            this.presenter = presenter;
        }

        public IEnumerator ReactToDamage(int DamageAmount)
        {
            hitPoints = Math.Max(0, hitPoints - DamageAmount);
            yield return presenter.TakeDamage();

            if (hitPoints <= 0)
            {
                yield return presenter.Die();
            }
        }
    }
}
