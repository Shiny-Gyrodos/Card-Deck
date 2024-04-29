using System.Xml.Linq;

public abstract class Deck 
{   
    public static List<Card> deck = [];
    public static int cardsInDeck;
    public static void Create()
    {       
        string[] titleOptions = {"two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "ace"};
        string[] royalTitleOptions = {"jack", "queen", "king"};

        for (int i = 2; i <= 11; i++)
        {
            deck.Add(new Card(i, "clubs", titleOptions[i - 2]));
            deck.Add(new Card(i, "spades", titleOptions[i - 2]));
            deck.Add(new Card(i, "hearts", titleOptions[i - 2]));
            deck.Add(new Card(i, "diamonds", titleOptions[i - 2]));
        }
        for (int i = 0; i < 3; i++)
        {
            deck.Add(new Card(10, "clubs", royalTitleOptions[i]));
            deck.Add(new Card(10, "spades", royalTitleOptions[i]));
            deck.Add(new Card(10, "hearts", royalTitleOptions[i]));
            deck.Add(new Card(10, "diamonds", royalTitleOptions[i]));
        }
        cardsInDeck = deck.Count;
    }

    //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    public static void Erase(bool createNewDeck)
    {
        deck.Clear();
        
        if (createNewDeck)
        {
            Create();
        }
    }
}

//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

public class Card
{
    public int value; // Parameter 1
    public string suite; // Parameter 2
    public string title; // Parameter 3
    public Card(int value, string suite, string title)
    {
        this.value = value;
        this.suite = suite;
        this.title = title;
    }
}

//|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

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

    //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

    public static void DrawCards(int howMany)
    {
        if (handLimit > Deck.cardsInDeck)
        {
            handLimit = Deck.cardsInDeck;
        }    

        for (int i = 1; i <= howMany; i++)
        {
            if (hand.Count < handLimit)
            {
                Card selectedCard = Deck.deck[random.Next(0, Deck.cardsInDeck)];
                hand.Add(selectedCard);
                Deck.deck.Remove(selectedCard);
            }
            else
            {
                Console.WriteLine("Hand limit reached.");
            }
        }
    }
}