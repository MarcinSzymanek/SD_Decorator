namespace SD_DecoratorApp.UI;

public abstract class UIBase
{
    private int _maxLogCount;
    protected readonly List<string> _log;

    public UIBase()
    {
        _maxLogCount = 2;
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
        if (_log.Count > 2)
        {
            _log[0] = _log[1];
            _log[1] = _log[2];
            _log[2] = text;
        }
        else
        {
            _log.Add(text);
        }

        Console.SetCursorPosition(0, 5);
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(new string(' ', Console.WindowWidth));
        }
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

    public void DisplayMainMenu()
    {
        Console.Write("Zero player game Decorator pattern demonstration\n\n");
        Console.Write("Rules: \n Player and monster take turns attacking until one of them is dead.");
        Console.Write("Once player defeats a monster, a new one is spawned\n");
        Console.Write("Menu:\n");
        Console.Write("a : Colored hit points in UI");
        Console.Write("b : More special monsters");
        Console.Write("c : Extra strong player");
        Console.Write("s : Start game");
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