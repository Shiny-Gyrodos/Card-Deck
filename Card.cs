using System.Xml.Linq;

public class Card
{
    public static int handLimit = 5; // Change when desired
    static Random random = new Random();
    public static List<Card> deck = new List<Card>();
    public static List<Card> hand = new List<Card>();
    static int cardsInDeck;
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
    public static void RemoveCardsFromHand(int howMany) /// Seperate player functions from deck functions in the future.
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
    public static void Draw(int howMany)
    {
        if (handLimit > cardsInDeck)
        {
            handLimit = cardsInDeck;
        }    

        for (int i = 1; i <= howMany; i++)
        {
            if (hand.Count < handLimit)
            {
                Card selectedCard = deck[random.Next(0, cardsInDeck)];
                hand.Add(selectedCard);
                deck.Remove(selectedCard);
            }
            else
            {
                Console.WriteLine("Hand limit reached.");
            }
        }
    }
}