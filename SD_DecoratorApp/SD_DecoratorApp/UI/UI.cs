using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SD_DecoratorApp.Monsters;

namespace SD_DecoratorApp.UI
{
    public class UI
    {
        private Monster _monster;
        private Monster _player;
        public UI(Monster player, Monster monster)
        {
            _player = player;
            _monster = monster;
        }
        
        public void Render()
        {

        }
    }
}
