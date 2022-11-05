using System;
using SD_DecoratorApp.Monsters;
using Character;
//using Character;

namespace SD_DecoratorApp.MonsterGenerator
{
    public class MonsterGenerator
    {
        Attribute attribute;
	    Random rand = new Random();
        public Monster SpawnMonster()
        {
            return new Monster();
        }
        public Monster SpawnSpecialMonster()
        {
            // Add decorator
            return new Monster();
        }
        public Monster SpawnMonster(Attributes attr)
        {
            return new Monster(attr);
        }
    }

}