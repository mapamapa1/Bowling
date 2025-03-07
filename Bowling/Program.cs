using Bowling.Entities;

namespace Bowling
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true) {

                Console.WriteLine("\nVälkommen till Bowlorama!");

                Console.WriteLine("Skriv 'spela' för att starta ett spel.");
                Console.WriteLine("Skriv 'stats' för att se statistik över tidigare matcher för en viss spelare.");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case ("spela"):
                        GameFacade gameFacade = new();
                        gameFacade.StartGame();
                        break;
                    case ("stats"):
                        Stats stats = new();
                        stats.StatsLoop();
                        break;

                }
        
            }
        }
    }
}
