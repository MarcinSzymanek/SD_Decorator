using Character;
using Character.Decorators;
using SD_DecoratorApp.Monsters;
using SD_DecoratorApp.UI;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

MonsterBaseAttributes atr = new MonsterBaseAttributes();
Console.WriteLine("Monester before decoration:");
Console.WriteLine("Monster1\nDamage: " + atr.Damage + "\nHp: " +  atr.Hp + "\nSize: " + atr.ModelScale); // Basic monster

DecoratorBig dec = new DecoratorBig(atr);
Console.WriteLine("After decorating:");
Console.WriteLine("Monster1\nDamage: " + dec.Damage + "\nHp: " +  dec.Hp + "\nSize: " + dec.ModelScale); // Decorated monster

Monster m = new Monster(dec);
Monster p = new Monster();
UI ui = new UI(p, m);
ui.Render();