using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card.CreateDeck();
            Card.Draw(5);
            
            foreach (Card card in Card.hand)
            {
                Console.WriteLine($"{card.value} {card.suite} {card.title}");
            }
            Console.ReadKey();
        }
    }
}