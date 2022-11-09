﻿using SD_DecoratorApp.Attributes;
using SD_DecoratorApp.Attributes.Decorators;
using SD_DecoratorApp.Monsters;


namespace SD_DecoratorApp.MonsterController;
public class MonsterController
{
    Random rand = new Random();
    public Monster SpawnMonster()
    {
        // Roll dice. 1 in 10 chance of special
        int dice = rand.Next(10);
        if (dice < 4)
        {
            int newDice = rand.Next(10);
            {
                if (newDice < 3)
                {
                    return new Monster(new DecoratorBig(new MonsterBaseAttributes()));
                }

                if (newDice < 6)
                {
                    return new Monster(new Armor(new MonsterBaseAttributes(), 1));
                }

                return new Monster(new CriticalChance(new MonsterBaseAttributes()));
            }
        }
        return new Monster();
    }

    public Monster SpawnPlayer()
    {
        return new Monster(new Armor(new PlayerBaseAttributes(), 1));
    }

    public void Buff(Monster target)
    {
        // Replace DecoratorBig with relevant buff: Add more decorators and roll dice
        Attributes.Attributes newAttr = new DecoratorBig(target.GetAttributes());
        target.Buff(newAttr);
    }
}