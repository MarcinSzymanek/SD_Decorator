using System.ComponentModel;

namespace Decorator_test
{
    /// <summary>
    /// Attributes is the component class (Abstract)
    /// </summary>
    public abstract class Attributes
    {
        // By declaring them virtual it allows them to be overridden by 
        // concrete components
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        private int _hp;
        public int Hp
        {
            get => _hp;
            set => _hp = value;
        }
        private int _damage;
        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }
        private float _speed;
        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }
        private float _modelScale;
        public float ModelScale
        {
            get => _modelScale;
            set => _modelScale = value;
        }

        // Operation
        public abstract void TakeDamage(int damage);

        public abstract void SetAttributes(Attributes attri);

    }

    /// <summary>
    /// MonsterAttributes is the concrete component class
    /// </summary>
    public class MonsterAttributes : Attributes
    {
        private string _race;
        public MonsterAttributes(
            string race,
            string name,
            int hp,
            int damage,
            float speed,
            float modelScale
            )
        {
            _race = race;
            Name = name;
            Hp = hp;
            Damage = damage;
            Speed = speed;
            ModelScale = modelScale;
        }

        public void Print()
        {
            Console.WriteLine($"Race: {_race} \n" +
                              $"Name: {Name} \n" +
                              $"Hp: {Hp} \n" +
                              $"Damage: {Damage} \n" +
                              $"Speed: {Speed} \n" +
                              $"Model scale: {ModelScale}\n\n");
        }

        public override void TakeDamage(int damage)
        {
            Hp -= damage;
        }

        public override void SetAttributes(Attributes attri)
        {
            Name = attri.Name;
            Hp = attri.Hp;
            Damage = attri.Damage;
            Speed = attri.Speed;
            ModelScale = attri.ModelScale;
        }

    }

    /// <summary>
    /// AttributesDecorator is the Decorator class (abstract)
    /// </summary>
    public abstract class AttributesDecorator : Attributes
    {
        // From dofactory.com - decorator
        protected Attributes Attri;

        public AttributesDecorator(Attributes attri)
        {
            Attri = attri;
        }

        public override void SetAttributes(Attributes attri)
        {
            Attri.SetAttributes(attri);
        }

        public override void TakeDamage(int damage)
        {
            Attri.TakeDamage(damage);
        }
    }

    /// <summary>
    /// DecoratorBig is a concrete decorator
    /// </summary>
    public class DecoratorBig : AttributesDecorator
    {
        protected float sizeIncrease; // >1

        public DecoratorBig(Attributes attri, float sizeIncrease)
            : base(attri)
        {
            this.sizeIncrease = sizeIncrease;

        }

        public override void SetAttributes(Attributes attri)
        {
            Console.WriteLine("Big decorator set attributes");
            Console.WriteLine("Values of attri:" +
            $"{attri.Hp} {attri.Speed} {attri.ModelScale} {attri.Name} {attri.Damage}");

            attri.Name = "Big " + attri.Name;
            attri.Hp = (int)(attri.Hp * sizeIncrease); // increase Hp as size increases
            Console.WriteLine($"attri speed: {attri.Speed} sizeIncrease: {sizeIncrease}");
            attri.Speed = attri.Speed * (2 - sizeIncrease); // decrease speed as size increases
            attri.ModelScale *= sizeIncrease; // increase model as size increases

            base.SetAttributes(attri);
        }

        public override void TakeDamage(int damage)
        {
            // This decorator does nothing with taking damage
        }

        public void Print()
        {
            Console.WriteLine($"Race:  \n" +
                              $"Name: {Name} \n" +
                              $"Hp: {Hp} \n" +
                              $"Damage: {Damage} \n" +
                              $"Speed: {Speed} \n" +
                              $"Model scale: {ModelScale}\n\n");
        }
    }

    /// <summary>
    /// DecoratorArmor is a concrete decorator of TakeDamageDecorator
    /// </summary>
    public class DecoratorArmor : AttributesDecorator
    {
        protected float Armor;
        protected float ArmorFactor = 0.06f;
        protected float ArmorBase = 1.0f;

        public DecoratorArmor(Attributes attri, float armor)
        : base(attri)

        {
            Armor = armor;
        }

        public void ChangeArmor(float armor)
        {
            Armor += armor;
            Console.WriteLine("DecoratorArmor.ChangeArmor amount: " + armor);
        }

        public override void TakeDamage(int damage)
        {
            Console.WriteLine("Armor decorator ");
            float tempDmg = Math.Abs(Armor - damage);
            //float tempDmg = 1 - (ArmorFactor * Armor) /
            //    (ArmorBase + ArmorFactor * Math.Abs(Armor));
            base.TakeDamage((int)tempDmg);
        }


        public override void SetAttributes(Attributes attri)
        {
            // This decorator does nothing with setting attributes
        }
    }
}
