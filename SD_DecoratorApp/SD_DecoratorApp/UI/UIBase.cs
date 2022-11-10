using System.ComponentModel.DataAnnotations;

namespace SD_DecoratorApp.UI;

public abstract class UIBase
{
    /*
     * This class was supposed to implement some ui rendering functions, and other ones be
     * Overriden (decorated). This approach failed due to lack of time, and is therefore a
     * Superclass which does all UI related things apart from Render-ing attributes
     */
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
    
    // A 5 line message log is being updated here
    // In retrospect, a fifo queue would be perfect here
    // Messages could be coloured easier if they were wrapped in an object with text and color
    // Properties
    public void Display(string text)
    {
        if (_log.Count > 4)
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

        
        // clears log area
        ClearLog();
        // writes the log
        Console.SetCursorPosition(0, 5);
        foreach (string item in _log)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearLog()
    {
        Console.SetCursorPosition(0, 5);
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
    }

    // This should honestly just be a ClearAttributeArea function, no need to clear log here
    public void ClearScreen()
    {
        Console.SetCursorPosition(0, 0);
        for (int j = 0; j < 20; j++)
        {
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(0, 0);
    }

    public void ClearAll()
    {
        Console.SetCursorPosition(0, 0);
        for (int j = 0; j < Console.WindowHeight; j++)
        {
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
        Console.SetCursorPosition(0, 0);
    }

    // A hacky way to implement special colored messages
    public void DisplaySpecial(string text, ConsoleColor color)
    {
        int posx = _rand.Next(11);
        int posy = _rand.Next(9, 13);
        Console.SetCursorPosition(posx, posy);
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ForegroundColor = ConsoleColor.White;
    }

    // Updates defeated monster count
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
        Console.Write("a : Toggle colored hit points in UI\n");
        Console.Write("b : Toggle Extra strong player\n");
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