using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bowling.Entities;

namespace Bowling.Entities
{
     public class GamePlayer
     {
         public Player Player { get; set; }
         public int Score { get; set; } = 0;

         public GamePlayer(Player player)
         {
             Player = player;
         }
     }    
}

