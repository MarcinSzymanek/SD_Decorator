using System.Collections;
using System.Collections.Generic;


namespace Character
{
	public interface IAttributes
	{
		string Name{get;}
		int Hp{get;}
		int Damage{get;}
		float Speed{get;}
		float ModelScale{get;}
		void SetAttributes(string name, int hp, int dmg, float spd, float scale);
	}	
}

