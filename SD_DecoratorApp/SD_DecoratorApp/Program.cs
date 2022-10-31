using Character;
using Character.Decorators;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

MonsterBaseAttributes atr = new MonsterBaseAttributes();
DecoratorBig dec = new DecoratorBig(atr);
Console.WriteLine("Monster1\nDamage: " + dec.Damage + "\nHp: " +  dec.Hp + "\nSize: " + dec.ModelScale);