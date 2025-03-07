using Bowling.Entities;

namespace Bowling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            GameFacade gameFacade = new(); // Single entry point

            while (true) {

                Console.WriteLine("\nVälkommen till Bowlorama!");

                Console.WriteLine("Skriv 'spela' för att starta ett spel.");
                Console.WriteLine("Skriv 'stats' för att se statistik över tidigare matcher för en viss spelare.");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case ("spela"):
                        gameFacade.StartGame();
                        break;
                    case ("stats"):
                        Stats stats = new();
                        stats.StatsLoop();
                        break;

                }
                
                void Game()
                {
                    Game game = new();

                    game.GameIntro();
                    game.GameLoop();

                }
        
            }
        }
    }
}
