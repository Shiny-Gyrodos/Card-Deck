using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card.CreateDeck();
            Player.DrawCards(5);
            
            foreach (Card card in Player.hand)
            {
                Console.WriteLine($"You drew {card.title} of {card.suite}");
            }
            Console.ReadKey();
        }
    }
}