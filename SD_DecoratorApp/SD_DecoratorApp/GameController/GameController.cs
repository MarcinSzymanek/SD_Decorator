using System.Runtime.InteropServices;
using System.Xml.Serialization;
using SD_DecoratorApp.Monsters;
using SD_DecoratorApp.UI;

namespace SD_DecoratorApp.GameController;

/* This class controls all initialization, menu and game logic
 * It should have been split up into more subcomponents, but
 * Having a turnmanager, aimanager and events is outside of the scope
 * Of this project
 */
public class GameController
{
    private UI.UIBase _ui;
    private MonsterController.MonsterController _monsterController;
    private Random _rand = new();

    private Monster _player;
    private Monster  _monster;
    private int _score = 0;
    private bool _running = false;
    private Turn _turn = Turn.PLAYER;
    private enum Turn
    {
        PLAYER = 1,
        MONSTER = 2
    };
    public GameController()
    {
        _ui = new UI.UI();
        InitMenu();
        
    }

    // User is presented with an introductory screen with a few options,
    // See UIBase for details
    // Afterwards entities are created using appropriate options and game is started
    private void InitMenu()
    {
        char c = ' ';

        _ui.DisplayMainMenu();

        bool godMode = false;
        bool coloredUi = true;
        while (c != 's' && c != 'q')
        {
            c = _ui.ChooseFromMenu();
            if (c == 'a')
            {
                if (!coloredUi)
                {
                    coloredUi = true;
                    Console.WriteLine("Colored hp on");
                }
                else
                {
                    coloredUi = false;
                    Console.WriteLine("Colored hp off");
                }
            }
            else if (c == 'b')
            {
                if (!godMode)
                {
                    godMode = true;
                    Console.WriteLine("Godmode activated");
                }
                else
                {
                    Console.WriteLine("Godmode deactivated");
                    godMode = false;
                }
            }
        }

        if (c == 'q')
        {
            Environment.Exit(0);
        }
        SetupGame();
        SetOptions(coloredUi, godMode);
        RunGame();
    }
    private void SetupGame()
    {
        Console.WriteLine("Initializing creatures");
        _monsterController = new();
        _player = _monsterController.SpawnPlayer();
        _monster = _monsterController.SpawnMonster();
    }

    /*
     * Contains main loop of the game
     * Does most of game logic - should definitely have been in another class
     */
    public void RunGame()
    {
        _ui.ClearScreen();
        _score = 0;
        _ui.UpdateScore(_score);
        _ui.Render(_player.GetAttributes(), _monster.GetAttributes());
        _running = true;
        while (_running)
        {
            _ui.ClearScreen();
            _ui.UpdateScore(_score);
            _ui.Render(_player.GetAttributes(), _monster.GetAttributes());
            if (_turn == Turn.PLAYER)
            {
                ProcessTurn(ref _player, ref _monster);
            }
            else
            {
                ProcessTurn(ref _monster, ref _player);
            }

            CheckWhoIsDead();
            _turn++;
            if ((int)_turn > 2)
            {
                _turn = Turn.PLAYER;
            }
        }
        // If we get this far, player is dead so print a message, wait for input and goto menu
        Console.WriteLine("Press any key to go to menu");
        Console.ReadKey();
        _ui.ClearAll();
        InitMenu();
    }

    // Also do some things after the check, sic
    // Also note multiple Sleep calls - probably these should just be moved to _ui.Display() function
    private void CheckWhoIsDead()
    {
        if (_player.CheckIfDead())
        {
            _ui.Display("");
            System.Threading.Thread.Sleep(500);
            _ui.Display("");
            System.Threading.Thread.Sleep(500);
            _ui.Display("");
            System.Threading.Thread.Sleep(500);
            _ui.Display("Slain by " + _monster.GetAttributes().Name);
            System.Threading.Thread.Sleep(500);
            _ui.Display("");
            System.Threading.Thread.Sleep(500);
            _ui.Display(_score + " Monsters defeated!");
            _running = false;
        }
        else if (_monster.CheckIfDead())
        {
            _ui.Display("");
            System.Threading.Thread.Sleep(200);
            _ui.Display("");
            System.Threading.Thread.Sleep(200);
            _ui.Display("Player defeated " + _monster.GetAttributes().Name + "!");
            System.Threading.Thread.Sleep(500);
            _monster = _monsterController.SpawnMonster();

            _ui.Display("A wild " + _monster.GetAttributes().Name + " appears!");

            _ui.Render(_player.GetAttributes(), _monster.GetAttributes());
            System.Threading.Thread.Sleep(500);
            _ui.Display("");
            System.Threading.Thread.Sleep(500);
            _score++;
            _ui.UpdateScore(_score);
        }
    }

    // Attack the target monster using source.Attr.Damage
    // A simplistic implementation which avoids adding Attack(target) function to monsters
    // and avoids events. Ideally a lot of these systems should be run by events,
    // but alas, here we are. Because of the lacking structure, the UI is a little buggy
    public void ProcessTurn(ref Monster source, ref Monster target)
    {
        // Get source damage and display a message
        int damage = source.GetAttributes().Damage;
        _ui.Display(source.GetAttributes().Name + " attacks for " + damage + "!");
        System.Threading.Thread.Sleep(250);
        // Roll a dice to add a small flavor text
        var f = PickFlavourText();
        if (f != null)
        {
            _ui.DisplaySpecial(f.text, f.color);
            System.Threading.Thread.Sleep(250);
        }
        // Target takes damage
        int taken = target.OnTakeDamage(damage);
        _ui.Display(target.GetAttributes().Name + " took " + taken + " damage");
        // Refresh display of monster attributes
        _ui.Render(_player.GetAttributes(), _monster.GetAttributes());
        System.Threading.Thread.Sleep(250);
    }


    /*
     * A small, fun, feature which should have been a decorator in the UI class
     */
    private class Flavour
    {
        public string text;
        public ConsoleColor color;
    }
    private Flavour? PickFlavourText()
    {
        int dice = _rand.Next(100);
        if (dice < 15)
        {
            var f = new Flavour();
            int newDice = _rand.Next(100);
            if (newDice < 40)
            {
                f.text = "KABLAAAM!";
                f.color = ConsoleColor.DarkRed;
            }
            else if(newDice < 80)
            {
                f.text = "SLASH!!!";
                f.color = ConsoleColor.DarkMagenta;
            }
            else
            {
                f.text = "OW!";
                f.color = ConsoleColor.DarkBlue;
            }

            return f;
        }

        return null;
    }

    // If godmode is on, make the player a little stronger
    // You can also turn off colors if you hate fun
    private void SetOptions(bool ColoredHp, bool GodMode)
    {
        Console.WriteLine("Setting options...");
        if (ColoredHp)
        {
            _ui = new DecoratorColoredStats(_ui);
        }

        if (GodMode)
        {
            _player = _monsterController.SpawnPlayer(true);
        }
    }
}