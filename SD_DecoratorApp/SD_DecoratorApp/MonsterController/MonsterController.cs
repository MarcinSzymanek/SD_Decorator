using SD_DecoratorApp.Attributes;
using SD_DecoratorApp.Attributes.Decorators;
using SD_DecoratorApp.Monsters;

//using Character;

namespace SD_DecoratorApp.MonsterController
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
            return new Monster();
        }

        public Monster SpawnPlayer()
        {
            return new Monster(new PlayerBaseAttributes());
        }

        public void Buff(Monster target)
        {
            // Replace DecoratorBig with relevant buff: Add more decorators and roll dice
            Attributes newAttr = new DecoratorBig(target.GetAttributes());
            target.Buff(newAttr);
        }
    }

}