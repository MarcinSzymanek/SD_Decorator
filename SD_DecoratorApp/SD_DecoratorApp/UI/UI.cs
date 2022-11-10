namespace SD_DecoratorApp.UI;
public class UI : UIBase
{
    public override void Render(Attributes.Attributes player, Attributes.Attributes enemy)
    {
        Console.SetCursorPosition(0, 0);
        string formatted = "";
        string line = ""; 
        line += player.Name;
        Separate(ref line);
        line += enemy.Name;
        formatted = AppendLine(ref line, formatted);
        line += "Hp: " + player.Hp;
        Separate(ref line);

        line += "Hp: " + enemy.Hp;
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