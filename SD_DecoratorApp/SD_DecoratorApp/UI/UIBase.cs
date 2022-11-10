using System.ComponentModel.DataAnnotations;

namespace SD_DecoratorApp.UI;

public abstract class UIBase
{
    private int _maxLogCount;
    Random _rand = new Random();
    protected readonly List<string> _log;

    public UIBase()
    {
        _maxLogCount = 3;
        _log = new List<string>(_maxLogCount);
    }
    public UIBase(int maxLog)
    {
        _maxLogCount = maxLog;
        _log = new List<string>(_maxLogCount);
    }

   
    protected void Separate(ref string line)
    {
        while (line.Length < 20)

        {
            line += ' ';
        }
    }

    protected string AppendLine(ref string line, string formatted)
    {
        formatted += line + "\n";
        line = "";
        return formatted;
    }

    public abstract void Render(Attributes.Attributes player, Attributes.Attributes enemy);
    
    public void Display(string text)
    {
        if (_log.Count > 3)
        {
            _log[0] = _log[1];
            _log[1] = _log[2];
            _log[2] = _log[3];
            _log[3] = text;
        }
        else
        {
            _log.Add(text);
        }

        Console.SetCursorPosition(0, 5);
        // clears log area
        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
        // writes the log
        Console.SetCursorPosition(0, 5);
        foreach (string item in _log)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearScreen()
    {
        Console.SetCursorPosition(0, 0);
        for (int j = 0; j < 20; j++)
        {
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(0, 0);
    }

    public void DisplaySpecial(string text, ConsoleColor color)
    {
        int posx = _rand.Next(7);
        int posy = _rand.Next(9, 11);
        Console.SetCursorPosition(posx, posy);
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    public void UpdateScore(int score)
    {
        Console.SetCursorPosition(0, 22);
        Console.WriteLine(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, 22);
        Console.WriteLine("Monsters defeated: " + score);
    }

    public void DisplayMainMenu()
    {
        Console.Write("\nZero player game Decorator pattern demonstration\n\n");
        Console.Write("Rules: \nPlayer and monster take turns attacking until one of them is dead.\n");
        Console.Write("Once player defeats a monster, a new one is spawned\n\n");
        Console.Write("Menu:\n");
        Console.Write("a : Colored hit points in UI\n");
        Console.Write("b : Extra strong player\n");
        Console.Write("s : Start game\n");
        Console.Write("q : Quit\n");
    }

    public char ChooseFromMenu()
    {
        string? input = null;
        while (String.IsNullOrEmpty(input))
        {
            input = Console.ReadLine();
        }

        return input[0];
    }
}