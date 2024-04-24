using System.Xml.Linq;

public class Card
{
    public static List<Card> deck = new List<Card>();
    public static int cardsInDeck;
    public int value; // Parameter 1
    public string suite; // Parameter 2
    public string title; // Parameter 3
    public Card(int value, string suite, string title)
    {
        this.value = value;
        this.suite = suite;
        this.title = title;
    }
    public static void CreateDeck()
    {
        string[] title = {"two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "ace"};
        string[] royalTitle = {"jack", "queen", "king"};
        for (int i = 2; i <= 11; i++)
        {
            deck.Add(new Card(i, "clubs", title[i - 2]));
            deck.Add(new Card(i, "spades", title[i - 2]));
            deck.Add(new Card(i, "hearts", title[i - 2]));
            deck.Add(new Card(i, "diamonds", title[i - 2]));
        }
        for (int i = 0; i < 3; i++)
        {
            deck.Add(new Card(10, "clubs", royalTitle[i]));
            deck.Add(new Card(10, "spades", royalTitle[i]));
            deck.Add(new Card(10, "hearts", royalTitle[i]));
            deck.Add(new Card(10, "diamonds", royalTitle[i]));
        }
        cardsInDeck = deck.Count();
    }
    public static void EraseDeck(bool createNewDeck)
    {
        deck.Clear();
        
        if (createNewDeck)
        {
            CreateDeck();
        }
    }
}



public abstract class Player // Abstract removes the ablitly to create an instance of the class.
{
    static Random random = new Random();
    public static List<Card> hand = new List<Card>();
    public static int handLimit = 5; /// Change when desired.
    public static void RemoveCardsFromHand(int howMany)
    {
        if (howMany > hand.Count)
        {
            howMany = hand.Count;
        }
        
        for (int i = 0; i < howMany; i++)
        {
            hand.RemoveAt(i);
        }
    }
    public static void DrawCards(int howMany)
    {
        if (handLimit > Card.cardsInDeck)
        {
            handLimit = Card.cardsInDeck;
        }    

        for (int i = 1; i <= howMany; i++)
        {
            if (hand.Count < handLimit)
            {
                Card selectedCard = Card.deck[random.Next(0, Card.cardsInDeck)];
                hand.Add(selectedCard);
                Card.deck.Remove(selectedCard);
            }
            else
            {
                Console.WriteLine("Hand limit reached.");
            }
        }
    }
}