using System.Runtime.CompilerServices;
using System.Threading.Channels;
using SD_DecoratorApp.Monsters;
using SD_DecoratorApp.UI;

namespace SD_DecoratorApp.GameController
{
    public class GameController
    {
        private UI.UIBase _ui;
        private MonsterController.MonsterController _monsterController;

        private Monster player;
        private Monster monster;
        private Attributes.Attributes source_attr;

        private Attributes.Attributes target_attr;

        private bool fighttillDeath = false;
        private bool _running = false;
        private Turn _turn = Turn.PLAYER;

        private enum Turn
        {
            PLAYER = 1,
            MONSTER = 2
        };

        public GameController()
        {
            SetupGame();
            RunGame();
        }

        private void SetupGame()
        {
            _monsterController = new();
            player = _monsterController.SpawnPlayer();
            monster = _monsterController.SpawnMonster();
            UI.UI ui = new UI.UI();
            _ui = new DecoratorColoredStats(ui);
        }

        public void RunGame()
        {
            _running = true;
            while (_running)
            {
                if (_turn == Turn.PLAYER)
                {
                    ProcessTurn(ref player, ref monster);
                }
                else
                {
                    ProcessTurn(ref monster, ref player);
                }

                if (player.CheckIfDead())
                {
                    _ui.Display("");
                    _ui.Display("");
                    _ui.Display("");
                    _ui.Display("GAME OVER");
                    _ui.Display("");
                    _running = false;
                }
                else if (monster.CheckIfDead())
                {
                    _ui.Display("Player defeated " + monster.GetAttributes().Name + "!");
                    monster = _monsterController.SpawnMonster();
                }

                _turn++;
                if ((int)_turn > 2)
                {
                    _turn = Turn.PLAYER;
                }
            }
        }

        public void ProcessTurn(ref Monster source, ref Monster target)
        {
            target.OnTakeDamage(source.GetAttributes().Damage);

            _ui.Display(source.GetAttributes().Name + " attacks!!");
            System.Threading.Thread.Sleep(500);
            _ui.ClearScreen();
            _ui.Render(player.GetAttributes(), monster.GetAttributes());
        }
    }
}