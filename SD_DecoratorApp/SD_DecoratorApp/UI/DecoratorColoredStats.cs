namespace SD_DecoratorApp.UI;
public class DecoratorColoredStats : UIBase
{
    private UIBase _uiBase;
    public DecoratorColoredStats(UIBase uiBase)
    {
        _uiBase = uiBase;
    }

    private void PickColor(int hp)
    {
        if (hp <= 6 && hp > 3)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }
        else if (hp <= 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
    public override void Render(Attributes.Attributes player, Attributes.Attributes enemy)
    {
        Console.SetCursorPosition(0, 0);
        string formatted = "";
        string line = "";
        line += player.Name;
        Separate(ref line);
        line += enemy.Name;
        formatted = AppendLine(ref line, formatted);
        Console.Write(formatted);

        PickColor(player.Hp);
        line += "Hp: " + player.Hp;
        Separate(ref line);
        Console.Write(line);
        line = "";
        Console.ForegroundColor = ConsoleColor.White;
        PickColor(enemy.Hp);
        line += "Hp: " + enemy.Hp;
        Console.Write(line);
        formatted = "";
        line = "";
        Console.ForegroundColor = ConsoleColor.White;
        formatted = AppendLine(ref line, formatted);

        line += "Damage: " + player.Damage;
        Separate(ref line);
        line += "Damage: " + enemy.Damage;
        formatted = AppendLine(ref line, formatted);
        line += "Speed: " + player.Speed;
        Separate(ref line);
        line += "Speed: " + enemy.Speed;
        formatted = AppendLine(ref line, formatted);
        Console.Write(formatted);
    }
}