using Character;
using Character.Decorators;
using SD_DecoratorApp.Monsters;
using SD_DecoratorApp.UI;

// See https://aka.ms/new-console-template for more information

MonsterBaseAttributes atr = new MonsterBaseAttributes();

DecoratorBig dec = new DecoratorBig(atr);
Monster m = new Monster(dec);
Monster p = new Monster();
UI ui = new UI(p, m);
ui.Render();

ui.Display("Monster attacks for " + m.GetAttributes().Damage + " Damage!");
ui.Display("Sometext");
ui.Display("Monster does things");
ui.Display("Check log");
ui.Display("Monster attacks!");

