using Character.Decorators;

namespace Character.Decorators
{

    public class Armor : Attributes, IDecorator
    {

        private readonly Attributes _attributes;
        private int _armor;
        public Armor(Attributes attributes, int armor)
        {
            _attributes = attributes;
            SetAttributes();
            _armor = armor;

        }
        private void SetAttributes()
        {
            Name = "Armored" + _attributes.Name;
            Hp = (int)(_attributes.Hp);
            Speed = _attributes.Speed;
            Damage = _attributes.Damage;
            ModelScale = _attributes.ModelScale;
        }

        public override void TakeDamage(int damage)
        {
            int dmgTaken = (damage - _armor);
            if (damage - _armor < 0)
            {
                dmgTaken = 0;
            }
            
            Hp = Hp - dmgTaken;
        }
        
    }
}
