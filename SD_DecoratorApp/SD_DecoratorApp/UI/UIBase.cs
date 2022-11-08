using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD_DecoratorApp.Attributes;
 

namespace SD_DecoratorApp.UI
{
    public abstract class UIBase 
    {
        protected readonly List<string> _log = new(3);
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

        public abstract void Render(IAttributes player, 
            IAttributes enemy);

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
    }
}
