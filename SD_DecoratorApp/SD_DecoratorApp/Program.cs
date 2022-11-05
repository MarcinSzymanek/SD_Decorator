using Character;
using Character.Decorators;
using SD_DecoratorApp.GameController;
using SD_DecoratorApp.MonsterGenerator;
using SD_DecoratorApp.Monsters;
using SD_DecoratorApp.UI;

// See https://aka.ms/new-console-template for more information

MonsterBaseAttributes atr = new MonsterBaseAttributes();
MonsterGenerator _gen = new();
DecoratorBig dec = new DecoratorBig(atr);
Monster m = _gen.SpawnMonster(dec);
Monster p = _gen.SpawnMonster();
UI ui = new UI(p, m);

GameController gc = new();
/*ui.Render();

ui.Display("Monster attacks for " + m.GetAttributes().Damage + " Damage!");
ui.Display("Sometext");
ui.Display("Monster does things");
ui.Display("Check log");
ui.Display("Monster attacks!");*/

