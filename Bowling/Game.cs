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

            Console.Write("Välj antal spelare(1-4): ");

            bool gameReady = false;

            _numberOfPlayers = int.Parse(Console.ReadLine()); //lägg till felhantering

            while (!gameReady) {

                for (int i = 1; i <= _numberOfPlayers; i++)
                {

                    ShowCurrentPlayers();

                    Console.WriteLine("");

                    Console.WriteLine($"Skriv in namn på spelare {i}:");

                    
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

                }

                ShowCurrentPlayers();

                Console.WriteLine();
                Console.WriteLine("\nTryck på en tangent för att starta spelet med dessa spelare.");

                Console.ReadKey(true);
                gameReady = true;             

            }

        }

        public void GameLoop()
        {
            GameLogic.GameRandomScore(GamePlayers);

            List<GamePlayer> sortedPlayers = GameLogic.SortPlacement(GamePlayers);

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