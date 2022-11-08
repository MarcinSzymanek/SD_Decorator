using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD_DecoratorApp.Monsters;

namespace SD_DecoratorApp.UI
{
    public class UI : UIBase
    {
        public override void Render(Attributes player, Attributes enemy)
        {
            string formatted = "";
            string line = ""; 
            line += "Player";
            Separate(ref line);
            line += "Monster";
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
}
