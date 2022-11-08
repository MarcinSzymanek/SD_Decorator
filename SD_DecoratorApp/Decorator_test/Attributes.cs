namespace Decorator_test
{
    public abstract class Attributes
    {
        public string Name {get; protected set;}
        public int Hp {get; protected set;}
        public int Damage {get; protected set;}
        public float Speed {get; protected set;}
        public float ModelScale {get; protected set;}

        public void TakeDamage(int damage)
        {
            Hp =- damage;
        }

        public void SetAttributes(
            string name,
            int hp,
            int damage,
            float speed,
            float modelScale)
        {
            Name = name;
            Hp = hp;
            Damage = damage;
            Speed = speed;
            ModelScale = modelScale;
        }

    }

    public class MonsterAttributes : Attributes
    {
        MonsterAttributes() : base()
        {

        }
        
    }

    public abstract class AttributesDecorator : Attributes
    {
        private readonly Attributes _attributes;
        protected AttributesDecorator(Attributes attributes)
        {
            _attributes = attributes;
        }

        public virtual void TakeDamage(int damage) =>
            _attributes.TakeDamage(damage);
        public virtual void SetAttributes(
            string name,
            int hp,
            int damage,
            float speed,
            float modelScale) =>
            _attributes.SetAttributes(name, hp, damage, speed, modelScale);
    }

    public class DecoratorBig : AttributesDecorator
    {
        DecoratorBig(Attributes attributes) : base(attributes)
        {

        }

        public override void SetAttributes(string name, int hp, int damage, float speed, float modelScale)
        {
            base.SetAttributes(
                "big "+ name, 
                (int)(hp * 1.5f), 
                damage, 
                speed * 0.9f, 
                modelScale * 0.8f
                );
        }
    }

    public class DecoratorArmor : AttributesDecorator
    {
        public float Armor { get; protected set; }
        DecoratorArmor(Attributes attributes, float armor) : base(attributes)
        {
            this.Armor = armor;
        }

        public override void TakeDamage(int damage)
        {
            base.TakeDamage((int)(damage - 1/Armor));
        }
    }
}
