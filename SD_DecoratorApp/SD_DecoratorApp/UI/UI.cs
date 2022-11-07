using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Character;
using SD_DecoratorApp.Monsters;

namespace SD_DecoratorApp.UI
{
    public class UI
    {
        private Attributes _playerAttr;
        private Attributes _monsterAttr;
        private int horizontal = 120;
        private int vertical = 60;
        private List<string> log = new(3);
        
        public void Display(string text)
        {
            if (log.Count > 2)
            {
                log[0] = log[1];
                log[1] = log[2];
                log[2] = text;
            }
            else
            {
                log.Add(text);
            }
            
            Console.SetCursorPosition(0, 5);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, 5);
            foreach (string item in log)
            {
                Console.WriteLine(item);
            }
        }

        public void Render(Attributes player, Attributes enemy)
        {
            // update Attributes
            Attributes playerAttr = player;
            Attributes monsterAttr = enemy;
            string formatted = "";
            string line = ""; 
            line += "Player";
            Separate(ref line);
            line += "Monster";
            formatted = AppendLine(ref line, formatted);
            line += "Hp: " + playerAttr.Hp;
            Separate(ref line);

            line += "Hp: " + monsterAttr.Hp;
            formatted = AppendLine(ref line, formatted);

            line += "Damage: " + playerAttr.Damage;
            Separate(ref line);
            line += "Damage: " + monsterAttr.Damage;
            formatted = AppendLine(ref line, formatted);
            line += "Speed: " + playerAttr.Speed;
            Separate(ref line);
            line += "Speed: " + monsterAttr.Speed;
            formatted = AppendLine(ref line, formatted);
            Console.Write(formatted);
        }

        private void Separate(ref string line)
        {
            while (line.Length < 20)
            {
                line += ' ';
            }
        }

        private string AppendLine(ref string line, string formatted)
        {
            formatted += line + "\n";
            line = "";
            return formatted;
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
    }
}
