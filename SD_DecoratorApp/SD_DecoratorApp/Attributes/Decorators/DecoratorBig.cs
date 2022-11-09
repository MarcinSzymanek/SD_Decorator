namespace Character.Decorators
{
    public class DecoratorBig : Attributes, IDecorator
    {
        private readonly Attributes _attributes;
        
        public DecoratorBig(Attributes attributes)
        {
            _attributes = attributes;
            SetAttributes();
        }

        private void SetAttributes()
        {
            Name = "Big" + _attributes.Name;
            Hp = (int)(_attributes.Hp * 1.5f);
            Speed = _attributes.Speed * 0.9f;
            Damage = _attributes.Damage;
            ModelScale = _attributes.ModelScale * 0.8f;
        }

    }
}