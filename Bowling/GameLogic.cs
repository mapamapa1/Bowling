using Bowling.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public static class GameLogic
    {
        public static void GameRandomScore(List<GamePlayer> players)
        {
            Random random = new Random(); 
            
            foreach(GamePlayer p in players)
            {
                int playerPoints = random.Next(0, 301);

                p.Score = playerPoints;

            }
                      
        }

        public static List<GamePlayer> SortPlacement(List<GamePlayer> players)
        {

            List<GamePlayer> sortedPlayers = players.OrderByDescending(p => p.Score).ToList();

            return sortedPlayers;
        }



    }
}
