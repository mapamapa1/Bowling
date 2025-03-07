using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Bowling.Entities;
using Bowling.Repository.Repos;

namespace Bowling
{
    internal class Game
    {

        public List<GamePlayer> GamePlayers { get; set; } = new();

        private Player _player;
        private int _numberOfPlayers;
        PlayerRepo repo = new();


        public void GameIntro()
        {



            bool gameReady = false;

            while (true)
            {
                Console.Write("Välj antal spelare(1-4): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out _numberOfPlayers) && _numberOfPlayers >= 1 && _numberOfPlayers <= 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ogiltigt val. Ange ett nummer mellan 1 och 4.");
                }
            }

            while (!gameReady)
            {

                ShowCurrentPlayers();

                Console.WriteLine("");

                Console.WriteLine($"Skriv in namn på spelare {GamePlayers.Count + 1}:");


                string playerName = Console.ReadLine();

                Player foundPlayer = new();

                foundPlayer = repo.MatchingUserName(playerName);

                if (foundPlayer != null)
                {

                    GamePlayer gamePlayer = new GamePlayer(foundPlayer);
                    GamePlayers.Add(gamePlayer);
                    Console.WriteLine("Spelare tillagd.");
                }
                else
                {

                    Console.WriteLine($"Spelare {playerName} inte hittad i databasen, skapa ny spelare med detta namn? j/n?");

                    string prompt = Console.ReadLine();

                    switch (prompt)
                    {
                        case ("j"):

                            Console.WriteLine("Var vänlig fyll i email-adress: ");

                            string email = Console.ReadLine();


                            foundPlayer = repo.CreateAndReturnNewPlayer(playerName, email);

                            GamePlayer gamePlayer = new GamePlayer(foundPlayer);
                            GamePlayers.Add(gamePlayer);
                            Console.WriteLine("Spelare tillagd");

                            break;
                        case ("n"):

                            break;
                        default:
                            break;

                    }

                }

                if (GamePlayers.Count == _numberOfPlayers)
                {
                    gameReady = true;
                }


            }

            ShowCurrentPlayers();

            Console.WriteLine();
            Console.WriteLine("\nTryck på en tangent för att starta spelet med dessa spelare.");

            Console.ReadKey(true);
            gameReady = true;                    

        }

        public void GameLoop()
        {
            GameServices.GameRandomScore(GamePlayers);

            List<GamePlayer> sortedPlayers = GameServices.SortPlacement(GamePlayers);

            Console.WriteLine("\nResultat: ");

            foreach(GamePlayer g in sortedPlayers)
            {
                Console.WriteLine($"{g.Player.UserName} : {g.Score} ");

            }

            MatchRepo matchRepo = new();
            matchRepo.SaveRecord(GamePlayers);

            Console.WriteLine($"Vinnare är: {sortedPlayers[0].Player.UserName}");

            SingletonLogger.Instance.Log("A game was played.");
            Console.WriteLine("\nTryck på en tangent för att gå tillbaka till menyn.");
            Console.ReadKey(true);


        }
        public void ShowCurrentPlayers()
        {
            Console.Write("\nTillagda spelare: ");
            
            foreach(GamePlayer p in GamePlayers)
            {
                Console.Write($" {p.Player.UserName},");

            }

        }
      

    }
}