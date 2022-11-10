using System.Runtime.InteropServices;
using System.Xml.Serialization;
using SD_DecoratorApp.Monsters;
using SD_DecoratorApp.UI;

namespace SD_DecoratorApp.GameController;

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
        _ui.DisplayMainMenu();
        char c = ' ';
        bool godMode = false;
        bool coloredUi = false;
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

    public void RunGame()
    {
        _ui.ClearScreen();
        _ui.UpdateScore(_score);
        _ui.Render(_player.GetAttributes(), _monster.GetAttributes());
        _running = true;
        while (_running)
        {
            if (_turn == Turn.PLAYER)
            {
                ProcessTurn(ref _player, ref _monster);
            }
            else
            {
                ProcessTurn(ref _monster, ref _player);
            }
            
            if (_player.CheckIfDead())
            {
                _ui.Display("");
                System.Threading.Thread.Sleep(500);
                _ui.Display("");
                System.Threading.Thread.Sleep(500);
                _ui.Display("");
                System.Threading.Thread.Sleep(500);
                _ui.Display("Slain by " + _monster.GetAttributes().Name);
                System.Threading.Thread.Sleep(1000);
                _ui.Display(_score + " Monsters defeated!");
                _running = false;
            }
            else if (_monster.CheckIfDead())
            {
                _ui.Display("Player defeated " + _monster.GetAttributes().Name + "!");
                _monster = _monsterController.SpawnMonster();
                _score++;
                _ui.UpdateScore(_score);
            }

            _turn++;
            if ((int)_turn > 2)
            {
                _turn = Turn.PLAYER;
            }
        }
    }

    public void ProcessTurn(ref Monster source, ref Monster target)
    {
        _ui.Display(source.GetAttributes().Name + " attacks for " + source.GetAttributes().Damage + "!");
        var f = PickFlavourText();
        if (f != null)
        {
            _ui.DisplaySpecial(f.text, f.color);
            System.Threading.Thread.Sleep(250);
        }
        System.Threading.Thread.Sleep(400);
        int taken = target.OnTakeDamage(source.GetAttributes().Damage);
        _ui.Display(target.GetAttributes().Name + " took " + taken + " damage");
        System.Threading.Thread.Sleep(500);
        _ui.ClearScreen();
        _ui.Render(_player.GetAttributes(), _monster.GetAttributes());
    }

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
            if (newDice < 50)
            {
                f.text = "KABLAAAM!";
                f.color = ConsoleColor.DarkRed;
            }
            else
            {
                f.text = "SLASH!!!";
                f.color = ConsoleColor.DarkMagenta;
            }

            return f;
        }

        return null;
    }

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