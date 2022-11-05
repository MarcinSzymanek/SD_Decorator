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
        private Monster _monster;
        private Monster _player;
        private int horizontal = 120;
        private int vertical = 60;
        public UI(Monster player, Monster monster)
        {
            _player = player;
            _monster = monster;
        }
        
        public void Render()
        {
            // Update attributes
            Attributes playerAttr = _player.GetAttributes();
            Attributes monsterAttr = _monster.GetAttributes();
            string formatted = "";
            string line = ""; 
            line += "Player";
            while (line.Length < 20) 
            { 
                line += ' ';
            }

            line += "Monster\n";
            formatted += line;

            line += "Hp: " + playerAttr.Hp;
            while (line.Length < 20)
            {
                line += ' ';
            }

            line += "Hp: " + monsterAttr.Hp + "\n";
            formatted += line;
            Console.Write(formatted);
        }
        

        private void ClearScreen()
        {

        }
    }
}
