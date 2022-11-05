using System;
using SD_DecoratorApp.Monsters;
using SD_DecoratorApp.Attributes;
//using Character;

namespace SD_DecoratorApp.MonsterGenerator
{
    public class MonsterGenerator
    {
        Attribute attribute;
	    public MonsterGenerator()
	    {
            Monster SpawnMonster()
            {
                return new Monster();
            }
            Monster SpawnSpecialMonster()
            {
                // Add decorator
                return new Monster();
            }
            Monster SpawnMonster(Attribute attr)
            {
                return new Monster(attr);
            }
	    }
    }

}