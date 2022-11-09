using Character.Decorators;
using System.Collections;
using System.Collections.Generic;

namespace Character
{
	public abstract class Attributes
	{
        public virtual string Name
        {
            get; protected set;
        }

        public Attributes(string name, int hp, int damage, float speed, float modelScale)
        {
            Name = name;
            Hp = hp;
            Damage = damage;
            Speed = speed;
            ModelScale = modelScale;
        }

        public virtual int Hp{get; private set; }
		public virtual int Damage{get; protected set;}
		public virtual float Speed{get; protected set;}
		public virtual float ModelScale{get; protected set;}

        public virtual void TakeDamage(int damage)
        {
            Hp -= damage;
        }
    }



}

