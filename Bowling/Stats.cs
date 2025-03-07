using Bowling.Entities;
using Bowling.Repository.Repos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class Stats
    {
        private PlayerRepo _playerRepo = new();

        public void StatsLoop()
        {
            while (true)
            {

                Console.WriteLine("\nSkriv in användarnamnet på spelaren vars matchstatistik du vill se:");
                Console.WriteLine("Skriv 'exit' för att gå tillbaka till huvudmenyn.");

                string userInput = Console.ReadLine();



                if (userInput.IsNullOrEmpty())
                {


                }
                else if(userInput == "exit")
                {
                    return;

                }

                else
                {
                    Player _player = new();

                    _player = _playerRepo.MatchingUserName(userInput);

                    if (_player != null)
                    {

                        DisplayMatchesByPlayer(_player.PlayerID);

                    }

                }
            }
        }

        public void DisplayMatchesByPlayer(int playerId)
        {
            MatchRepo repo = new();

            var matches = repo.GetMatchesByPlayer(playerId);

            if (matches.Count == 0)
            {
                Console.WriteLine("Inga matcher hittade för denna spelare.");
                return;
            }

            Console.WriteLine($"Tidigare matcher:");
            foreach (var matchPlayer in matches)
            {
                Console.WriteLine($"Match {matchPlayer.Match.Date}: {matchPlayer.Score} poäng");
            }
        }


    }
}
