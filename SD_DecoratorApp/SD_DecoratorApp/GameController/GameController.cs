using System.Runtime.CompilerServices;
using System.Threading.Channels;
using Character;
using SD_DecoratorApp.Monsters;

namespace SD_DecoratorApp.GameController;

public class GameController
{
    // private UI _ui = new();

    private Monster player;
    private Monster  monster;
    private Attributes source_attr;
    private Attributes target_attr;
    private bool fighttillDeath = false;


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

    public void processTurn(Monster attacker, Monster defender)
    {
        while(fighttillDeath == false)
        {

            attack(attacker, defender);
            attack(defender, attacker);
            if(attacker.CheckIfDead() || defender.CheckIfDead())
            {
                fighttillDeath = true;
            }
            Thread.Sleep(500);
        }
    }

}