using Character.Decorators;

namespace Character.Decorators
{

    public class Armor : AttributesDecorator
    {
        private readonly int _armor;
        public override string Name
        {
            get => "Armored " + base.Name;
        }
        public Armor(Attributes attributes, int armor) : base(attributes)
        {
            _armor = armor;

        }

        public override void TakeDamage(int damage)
        {
            int dmgTaken = (damage - _armor);
            if (damage - _armor < 0)
            {
                dmgTaken = 0;
            }

            base.TakeDamage(dmgTaken);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Blocked: " + _armor);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
    }
}
