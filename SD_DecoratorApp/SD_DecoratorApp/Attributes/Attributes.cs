using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
	public abstract class Attributes: IAttributes
	{
		public abstract string Name{get; protected set; }
		public abstract int Hp{get; protected set; }
		public abstract int Damage{get; protected set;}
		public abstract float Speed{get; protected set;}
		public abstract float ModelScale{get; protected set;}
		public abstract void SetAttributes(string name, int hp, int dmg, float spd, float scale);    
	}	
}

