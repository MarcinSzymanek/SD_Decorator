namespace Character.Decorators
{
    public class CriticalChance : Attributes, IDecorator
    {


        private readonly Attributes _attributes;
        public CriticalChance(Attributes attributes)
        {
            _attributes = attributes;
            SetAttributes();
        }


        private void SetAttributes()
        {
            Name =  _attributes.Name;
            Hp = (int)(_attributes.Hp * 1.5f);
            Speed = _attributes.Speed * 0.9f;
            Damage = _attributes.Damage;
            ModelScale = _attributes.ModelScale * 0.8f;
        }

        public void TakeDamage(int damage)
        {
            Random rnd = new Random();
            var crit = rnd.Next(1, 101);
            var x = crit < 25 ? damage = damage * 2 : damage = damage;
            Hp = Hp + damage;
        }


    }
}
