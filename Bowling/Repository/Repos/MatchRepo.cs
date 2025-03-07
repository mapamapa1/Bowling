using Bowling.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.Repository.Repos
{
    public class MatchRepo
    {
        private readonly DataContext _context;
        public MatchRepo()
        {
            _context = new DataContext();
        }

        public void SaveRecord(List<GamePlayer> gamePlayers)
        {

            Match match = new();

            match.Date = DateTime.Now;
            match.MatchPlayers = new List<MatchPlayer>();

            foreach (var gamePlayer in gamePlayers)
            {
                MatchPlayer matchPlayer = new();

                matchPlayer.MatchID = match.MatchID;
                matchPlayer.PlayerID = gamePlayer.Player.PlayerID;
                matchPlayer.Score = gamePlayer.Score;
                matchPlayer.Match = match;

                match.MatchPlayers.Add(matchPlayer);
            }

            _context.Matches.Add(match);
            _context.SaveChanges();

        }

        public List<MatchPlayer> GetMatchesByPlayer(int playerId)
        {
            return _context.MatchPlayers
                .Where(mp => mp.PlayerID == playerId) // Filter by player ID
                .Include(mp => mp.Match) // Include match details
                .ToList();
        }


    }
}
