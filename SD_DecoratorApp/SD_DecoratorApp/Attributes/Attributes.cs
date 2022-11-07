using Character.Decorators;
using System.Collections;
using System.Collections.Generic;

namespace Character
{
	public abstract class Attributes
	{
		public string Name{get; protected set; }
		public int Hp{get; protected set; }
		public int Damage{get; protected set;}
		public float Speed{get; protected set;}
		public float ModelScale{get; protected set;}

        public void TakeDamage(int damage)
        {
            Hp = Hp - damage;
        }
    }



}

