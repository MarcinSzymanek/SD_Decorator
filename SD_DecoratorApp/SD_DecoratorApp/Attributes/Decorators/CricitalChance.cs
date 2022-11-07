namespace Character.Decorators
{
    public class CriticalChance : Attributes, IDecorator
    {
        private Random rand = new Random();
        private int _damage;
        public override int Damage {
            get
            {
                int dice = rand.Next(100);
                if (dice < 25)
                {
                    return Damage * 2;
                }

                return Damage;
            }
            protected set
            {
                _damage = value;
            }
        }

        private readonly Attributes _attributes;
        public CriticalChance(Attributes attributes)
        {
            _attributes = attributes;
            SetAttributes();
        }


        private void SetAttributes()
        {
            Name =  _attributes.Name;
            Hp = (int)(_attributes.Hp);
            Speed = _attributes.Speed;
            Damage = _attributes.Damage;
            ModelScale = _attributes.ModelScale;
        }
    }
}
