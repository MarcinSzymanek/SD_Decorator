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
            Name = _attributes.Name;
            Hp = (int)(_attributes.Hp * 1.5f);
            Speed = _attributes.Speed * 0.9f;
            Damage = _attributes.Damage;
            ModelScale = _attributes.ModelScale * 0.8f;
        }


        
        public void TakeDamage(int damage)
        {
            Hp = Hp - (damage - _armor);
        }
        
    }
}
