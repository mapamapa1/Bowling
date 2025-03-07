using Bowling.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Repository.Repos
{
    internal class PlayerRepo //Här används Repository pattern för att samla all kommunikation med databasen i egna klasser
    {
        private readonly DataContext _context;

        public PlayerRepo()
        {
            _context = new DataContext();
        }
        public Player MatchingUserName(string condition)
        {
            var player = _context.Players.FirstOrDefault(p => p.UserName == condition);

            if (player != null)
            {
                return player;
            }

            return null;

        }
                
        public Player CreateAndReturnNewPlayer(string username, string email)
        {
            Player newPlayer = new();

            newPlayer.UserName = username;
            newPlayer.Email = email;

            _context.Players.Add(newPlayer);
            _context.SaveChanges();

            return newPlayer;

        }


    }
}
