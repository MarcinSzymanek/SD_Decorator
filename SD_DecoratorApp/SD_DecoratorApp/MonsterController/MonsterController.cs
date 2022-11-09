﻿using System;
using SD_DecoratorApp.Monsters;
using Character;
using Character.Decorators;

//using Character;

namespace SD_DecoratorApp.MonsterGenerator
{
    public class MonsterController
    {
        Random rand = new Random();
        public Monster SpawnMonster()
        {
            // Roll dice. 1 in 10 chance of special
            int dice = rand.Next(10);
            if (dice == 0)
            {
                return new Monster(new DecoratorBig(new MonsterBaseAttributes()));
            }

            if (dice == 1)
            {
                return new Monster(new Armor(new MonsterBaseAttributes(), 1));
            }
            return new Monster();
        }

        public Monster SpawnPlayer()
        {
            return new Monster(new Armor(new PlayerBaseAttributes(), 10));
        }

        public void Buff(Monster target)
        {
            // Replace DecoratorBig with relevant buff: Add more decorators and roll dice
            Attributes newAttr = new DecoratorBig(target.GetAttributes());
            target.Buff(newAttr);
        }
    }

}