﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class GameFacade  
    {
        private Game _game;

        public GameFacade()
        {
            _game = new Game();
        }

        public void StartGame()
        {
            // TODO: make a call to db here
            _game.GameIntro();
            _game.GameLoop();
        }

    }
}
