namespace Character.Decorators
{
    public class DecoratorBig : Attributes
    {
        private readonly Attributes _attributes;
        
        public override string Name { get; protected set; } 
        public override int Hp { get; protected set;} 
        public override float Speed { get; protected set;} 
        public override int Damage { get; protected set;} 
        public override float ModelScale { get; protected set;} 
        
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
        public override void SetAttributes(string name, int hp, int dmg, float spd, float scale)
        {
            
        } 
    }
}