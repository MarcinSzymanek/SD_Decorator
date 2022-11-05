using System.Runtime.CompilerServices;
using System.Threading.Channels;
using Character;
using Character.Decorators;
using SD_DecoratorApp.Monsters;

namespace SD_DecoratorApp.GameController;

public class GameController
{
    private UI.UI _ui;

    private Monster player;
    private Monster  monster;
    private Attributes source_attr;

    private Attributes target_attr;

    private bool fighttillDeath = false;

    public GameController()
    {
        SetupGame();
        ProcessTurn();
    }

    private void SetupGame()
    {
        player = new Monster();
        monster = new Monster(new DecoratorBig(new MonsterBaseAttributes()));
        _ui = new(player, monster);
    }
    public void attack(Monster source, Monster target)
    {
        source_attr = source.GetAttributes();
        target_attr = target.GetAttributes();

        target.OnTakeDamage(source_attr.Damage);
    }
    /*
    void Buff(Attributes tar, IDecorator dec)
    {
        tar = (Attribute) dec;
        
    }
    */

    public void ProcessTurn()
    {
        while(fighttillDeath == false)
        {
            
            attack(player, monster);
            _ui.Display("Player " + "Attacks!!");
            attack(monster, player);
            _ui.Display("Monster attacks player!");
            if(player.CheckIfDead() || monster.CheckIfDead())
            {
                fighttillDeath = true;
            }
            Thread.Sleep(500);
            _ui.ClearScreen();
            _ui.Render();
        }
    }

}