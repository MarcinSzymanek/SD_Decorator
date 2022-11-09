using System.ComponentModel;

//namespace Decorator_test
//{
//    /// <summary>
//    /// Attributes is the component class (Abstract)
//    /// </summary>
//    public abstract class Attributes 
//    {
//        // By declaring them virtual it allows them to be overridden by 
//        // concrete components
//        public virtual string Name {get; set;}
//        public virtual int Hp {get; set;}
//        public virtual int Damage {get; set;}
//        public virtual float Speed {get; set;}
//        public virtual float ModelScale {get; set;}

//        // constructor
//        Attributes(string name, int hp, int damage, float speed, float modelScale)
//        {
//            Name = name;
//            Hp = hp;
//            Damage = damage;
//            Speed = speed;
//            ModelScale = modelScale;
//        }

//        // Operation
//        public virtual void TakeDamage(int damage)
//        {
//            Hp =- damage;
//        }

//        // Operation
//        public virtual void SetAttributes(
//            string name,
//            int hp,
//            int damage,
//            float speed,
//            float modelScale)
//        {
//            Name = name;
//            Hp = hp;
//            Damage = damage;
//            Speed = speed;
//            ModelScale = modelScale;
//        }

//    }

//    /// <summary>
//    /// MonsterAttributes is the concrete component class
//    /// </summary>
//    public class MonsterAttributes : Attributes
//    {
//        MonsterAttributes(string name,
//            int hp,
//            int damage,
//            float speed,
//            float modelScale) : base(name,
//            hp,
//            damage,
//            speed,
//            modelScale)
//        {
//            Name = name;
//            Hp = hp;
//            Damage = damage;
//            Speed = speed;
//            ModelScale = modelScale;
//        }
//        //public override string Name {get; protected set;}
//        //public override int Hp {get; protected set;}
//        //public override int Damage {get; protected set;}
//        //public override float Speed {get; protected set;}
//        //public override float ModelScale {get; protected set;}
//    }

//    /// <summary>
//    /// AttributesDecorator is the Decorator class (abstract)
//    /// </summary>
//    public abstract class AttributesDecorator : Attributes
//    {
//        // From dofactory.com - decorator
//        protected Attributes? attributes;

//        public void SetComponent(Attributes attributes)
//        {
//            this.attributes = attributes;
//        }

//        public override void SetAttributes(
//            string name,
//            int hp,
//            int damage,
//            float speed,
//            float modelScale
//            )
//        {
//            if (attributes != null)
//            {
//                attributes.SetAttributes(name,hp,damage,speed,modelScale);
//            }
//        }



//        //private readonly Attributes _attributes;
//        //protected AttributesDecorator(Attributes attributes)
//        //{
//        //    _attributes = attributes;
//        //}

//        //public virtual void TakeDamage(int damage) =>
//        //    _attributes.TakeDamage(damage);
//        //public virtual void SetAttributes(
//        //    string name,
//        //    int hp,
//        //    int damage,
//        //    float speed,
//        //    float modelScale) =>
//        //    _attributes.SetAttributes(name, hp, damage, speed, modelScale);
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
//            addedBehavior();
//        }

//        void addedBehavior()
//        {
//            Console.WriteLine("Im added extra behavior");
//        }


//        //private DecoratorBig(Attributes attributes) : base(attributes)
//        //{

//        //}

//        //public override void SetAttributes(string name, int hp, int damage, float speed, float modelScale)
//        //{
//        //    base.SetAttributes(
//        //        "big "+ name, 
//        //        (int)(hp * 1.5f), 
//        //        damage, 
//        //        speed * 0.9f, 
//        //        modelScale * 0.8f
//        //        );
//        //}
//    }

//    /// <summary>
//    /// DecoratorArmor is a concrete decorator
//    /// </summary>
//    public class DecoratorArmor : AttributesDecorator
//    {
//        private float Armor { get; set; }

//        public override void TakeDamage(int damage)
//        {
//            base.TakeDamage((int)(damage - 1/Armor));
//        }

//        //private float Armor { get; set; }

//        //private DecoratorArmor(Attributes attributes, float armor) 
//        //    : base(attributes)
//        //{
//        //    Armor = armor;
//        //}

//        //public override void TakeDamage(int damage)
//        //{
//        //    base.TakeDamage((int)(damage - 1/Armor));
//        //}
//    }
//}
