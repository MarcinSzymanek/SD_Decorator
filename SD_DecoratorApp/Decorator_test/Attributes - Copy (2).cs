//using System.ComponentModel;

//namespace Decorator_test
//{
//    /// <summary>
//    /// Attributes is the component class (Abstract)
//    /// </summary>
//    public abstract class Attributes
//    {
//        // By declaring them virtual it allows them to be overridden by 
//        // concrete components
//        //public virtual string Name {get; set;}
//        //public virtual int Hp {get; set;}
//        //public virtual int Damage {get; set;}
//        //public virtual float Speed {get; set;}
//        //public virtual float ModelScale {get; set;}
//        public string Name { get; set; }
//        public int Hp { get; set; }
//        public int Damage { get; set; }
//        public float Speed { get; set; }
//        public float ModelScale { get; set; }

//        // Operation
//        public virtual void TakeDamage(int damage)
//        {
//            Hp -= damage;
//        }

//        public virtual void SetAttributes() { }

//    }

//    /// <summary>
//    /// MonsterAttributes is the concrete component class
//    /// </summary>
//    public class MonsterAttributes : Attributes
//    {
//    }

//    /// <summary>
//    /// AttributesDecorator is the Decorator class (abstract)
//    /// </summary>
//    public abstract class AttributesDecorator : Attributes
//    {
//        // From dofactory.com - decorator
//        protected Attributes? Attri;

//        public void SetComponent(Attributes attributes)
//        {
//            this.Attri = attributes;
//        }

//        public virtual void SetAttributes(
//            string name,
//            int hp,
//            int damage,
//            float speed,
//            float modelScale
//            )
//        {
//            if (Attri != null)
//            {
//                Console.WriteLine("AttributesDecorator.SetAttributes setting Attributes");
//                Attri.Name = name;
//                Attri.Hp = hp;
//                Attri.Damage = damage;
//                Attri.Speed = speed;
//                Attri.ModelScale = modelScale;
//            }
//        }
//    }

//    /// <summary>
//    /// DecoratorBig is a concrete decorator
//    /// </summary>
//    public class DecoratorBig : AttributesDecorator
//    {
//        public override void SetAttributes(
//            string name,
//            int hp,
//            int damage,
//            float speed,
//            float modelScale
//        )
//        {
//            base.SetAttributes(
//                "big " + name,
//                (int)(hp * 1.5f),
//                damage,
//                speed * 0.9f,
//                modelScale * 0.8f
//             );
//            AddedBehavior();
//        }

//        void AddedBehavior()
//        {
//            Console.WriteLine("Im added extra behavior");
//        }
//    }

//    /// <summary>
//    /// AttributesDecorator is the Decorator class (abstract)
//    /// </summary>
//    public abstract class TakeDamageDecorator : Attributes
//    {
//        // From dofactory.com - decorator
//        protected Attributes? Attri;

//        public void SetComponent(Attributes attributes)
//        {
//            this.Attri = attributes;
//        }

//        public override void TakeDamage(int damage)
//        {
//            Console.WriteLine("hello");
//            if (Attri != null)
//            {
//                Attri.TakeDamage(damage);
//                Console.WriteLine("TakeDamageDecorator.TakeDamage: " + damage);
//            }
//        }
//    }

//    /// <summary>
//    /// DecoratorArmor is a concrete decorator of TakeDamageDecorator
//    /// </summary>
//    public class DecoratorArmor : TakeDamageDecorator
//    {
//        private float Armor { get; set; }
//        private float ArmorFactor = 0.06f;
//        private float ArmorBase = 1.0f;

//        public override void TakeDamage(int damage)
//        {
//            float tempDmg = 1 - ((ArmorFactor * Armor) /
//                                 (ArmorBase + ArmorFactor * Math.Abs(Armor)));
//            base.TakeDamage((int)(
//                1 - ((ArmorFactor * Armor) /
//                    (ArmorBase + ArmorFactor * Math.Abs(Armor))))
//                );
//            Console.WriteLine("DecoratorArmor.TakeDamage amount: " + tempDmg);
//        }

//        public void ChangeArmor(float armor)
//        {
//            Armor += armor;
//            Console.WriteLine("DecoratorArmor.ChangeArmor amount: " + armor);
//        }
//    }
//}
