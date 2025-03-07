using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class GameFacade  //här används Facade pattern för att 
    {
        private Game _game;

        public GameFacade()
        {
            _game = new Game();
        }

        public void StartGame()
        {
            _game.GameIntro();
            _game.GameLoop();
        }

    }
}
