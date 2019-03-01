using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodingExercise6
{
    class Program
    {
        public static Dictionary<string, ConsoleColor> colorOf = new Dictionary<string, ConsoleColor>() //created a dictionary to hold the colors of my card symbols
            {
                {"S", ConsoleColor.Black },
                {"C", ConsoleColor.Black },
                {"D", ConsoleColor.Red },
                {"H", ConsoleColor.Red }
            };

        public static Dictionary<string, char> mySymbols = new Dictionary<string, char>() //created a dictionary to hold my symbols
            {
                {"S", '\u2660'},
                {"C", '\u2663'},
                {"D", '\u2666'},
                {"H", '\u2665'}
            };

        public static Dictionary<string, int> valueOf = new Dictionary<string, int>() //created a dictionary to hold the values of the cards
            {
                {"2", 2 },
                {"3", 3 },
                {"4", 4 },
                {"5", 5 },
                {"6", 6 },
                {"7", 7 },
                {"8", 8 },
                {"9", 9 },
                {"10", 10 },
                {"J", 12 },
                {"Q", 12 },
                {"K", 12 },
                {"A", 15 }
            };

        public static Dictionary<int, string> positionOf = new Dictionary<int, string>() //created a dictionary to hold the winning-place positions
        {
            {1, "1st" },
            {2, "2nd" },
            {3, "3rd" },
            {4, "4th" },
            {5, "5th" },
            {6, "6th" }
        };

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //enables the symbols

            List<string> myCards = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" }; //list to hold my cards
            List<string> mySuits = new List<string>() { "S", "C", "D", "H" }; //list to hold my suits

            List<string> new_deck = new List<string>(); //unshuffled deck holder
            List<string> shuffled_deck = new List<string>(); //shuffled deck holder

            foreach (string card in myCards) //creates the individual cards w/ the suits and adds it to the unshuffled deck holder list
            {
                foreach (string suit in mySuits)
                {
                    new_deck.Add(suit + card);
                }
            }
            shuffled_deck = Shuffle(new_deck); //sends unshuffled deck to shuffle function, shuffles the cards, then places them inside shuffled_deck list
            
            Console.Write("Welcome to '");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Lucky ");
            Console.ForegroundColor = ConsoleColor.Green;  //Title screen
            Console.Write("Spade ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Cards");
            Console.ResetColor();
            Console.Write("!'");

            Console.WriteLine("\n\n\n Intructions:\n" +
                "~ In a deck, there are 52 cards...\n" +
                "~ 4 suits of Hearts, Spades, Diamonds, and Clubs\n" +
                "~ Each suit contains 13 cards with various values:\n" +     //instructions 
                "~ 2-10: Same as face value\n" +
                "~ Jack: 12\n" +
                "~ Queen: 12\n" +
                "~ King: 12\n" +
                "~ Ace: 15\n\n" +
                "You will be playing a game of chance against 3 other opponents to \nsee who ends up with the most amount of cards being delt out.\n\n" +
                "Press enter when you're ready to enter the player's names!");

            Console.ReadKey();
            Console.Clear();    //new screen

            Dictionary<string, List<string>> playerHas = new Dictionary<string, List<string>>(); //Dictionary to hold individual player and his/her cards
            List<string> myPlayers = new List<string>(); //List of players 
            string player; //individual player variable

            Console.WriteLine("Enter 4 players below:\n "); //prompts user to enter 4 players
            do //create players until player count has reached 4
            {
                Console.Write("  Enter player's name: "); //This is where the user will enter player 1-4's names
                player = Console.ReadLine();
                if (player != null)
                {
                    myPlayers.Add(player); //adds the player's name to list
                    playerHas[player] = new List<string>{}; //adds the player's name to dictionary
                }
            } while (myPlayers.Count < 4);

            Dictionary<string, int> playerTotal = new Dictionary<string, int>(); //Dictionary to hold individual player and his card count total

            Console.WriteLine("\nDealing Cards: \n"); //Shows the card game after this message
            foreach(string playr in myPlayers)
            { 
                int my_total = 0;
                for (int i = 0; i < 13; i++) //deals out 13 cards to each of the 4 players
                {
                    string myCard = shuffled_deck[0];
                    shuffled_deck.RemoveAt(0);
                    playerHas[playr].Add(myCard);
                    my_total += valueOf[myCard.Substring(1)];
                }
                playerTotal[playr] = my_total; //adds up the cards per player

            }
            int position = 0;
            int cardTotal = 0;
            var winnersVar = from entry in playerTotal orderby entry.Value descending select entry; //puts the players in descending order according to win placing
            foreach(KeyValuePair<string, int> opponent in winnersVar)
            {
                Console.Write(positionOf[++position] + " Place: " + opponent.Key + ": "); //Shows the user the win placing
                foreach(string card in playerHas[opponent.Key])
                {
                    showCard(card);
                }
                Console.WriteLine("  " + opponent.Value + "\n");
                cardTotal += opponent.Value;
            }
            Console.WriteLine("Total Deck Score: " + cardTotal + "\n\n"); //Shows the user the total deck count (420)
        }

        public static List<string> Shuffle(List<string> cardDeck) //function to shuffle the deck
        {
            Random rdm = new Random();

            List<string> shuffledDeck = new List<string>();

            int n = cardDeck.Count;

            while (n > 0)
            {
                n--;
                int k = rdm.Next(n + 1);
                string value = cardDeck[k];
                cardDeck[k] = cardDeck[n];
                cardDeck[n] = value;
                shuffledDeck.Add(value);
            }

            return shuffledDeck;
        }

        public static void showCard(string card) //function to create the card's cosmetics (white background + suit & call to colorOf)
        {
            string suit = card.Substring(0, 1);
            string faceValue = card.Substring(1);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = colorOf[suit];

            Console.Write(" " + mySymbols[suit] + " " + faceValue + " ");

            Console.ResetColor();

            Console.Write(" ");
        }
    }
}
