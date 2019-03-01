using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodingExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            var hints = new List<string> { "They have great blue jeans!", "SUPER CASH COUPONS", "Sister store of Gap & Banana Republic", "$10 Jeans for kids & $15 for adults", "'Great Prices for the Whole Family'", "No adult without kids has ever been to the back of the store", "$1 flip-flops", "Color of their logo is also in their name", "Usually in shopping malls" };
            //list of hint strings
            
            int runCount = 10; //attempts set to 10
            do
            {
                Console.WriteLine("Welcome to 'Guess Which Clothing Brand I'm Thinking Of!'\n"); //displays the game info to the user - main menu
                Console.WriteLine("Im thinking of a common clothing brand with these set of clues:\n" +
                    "1. The title is two words\n" +
                    "2. The first word begins with 'O' and the second word ends with 'y'\n" +
                    "3. Kids to adults shop here\n" +
                    "4. Their dressing rooms are usually unmanaged and dirty\n" +
                    "\nTry to guess with these set of clues. If you need another hint, just type 'hint'.\n\n" +
                    "Only " + runCount + " attempts left."); //displays current amount of attempts left

                string input = Console.ReadLine();

                

                switch (input) //switch begins
                {
                    case "oldnavy": //close to correct answer
                        {
                            Console.Clear();

                            Console.WriteLine("Well... You're pretty much right but can you do a better job of typing it? Press enter to try again..."); //informs user that he is close but needs to clean up input
                            runCount--; //subtracts attempt number
                            Console.ReadKey();
                            Console.Clear();

                        }
                        break;
                    case "old navy": //close to correct answer
                        {
                            Console.Clear();

                            Console.WriteLine("Ohhhhhh! So close, but I'm looking for capitalizations too! Press enter to try again..."); //informs user that he is close but needs to capitalize
                            runCount--; //subtracts attempt number
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "Old Navy": //correct answer
                        {
                            Console.Clear();

                            Console.WriteLine("CONGRATULATIONS! You are correct!!!"); //informs the user that he/she won
                            Console.Write("Thanks for playing! Press enter to exit the game"); //thanks the user for playing

                            runCount = 0; //closes the application
                        }
                        break;
                    default: //any other wrong answer, do this
                        {
                            Console.Clear();

                            Console.WriteLine("Incorrect! Try again..."); //informs user that he/she is incorrect
                            runCount--; //subtracts attempt number
                            Console.ReadKey();
                            Console.Clear();

                        }
                        break;
                    case "hint": //if user types hint, displays hint
                    case "Hint":
                        {
                            Console.Clear();

                            Random rnd = new Random();

                            int hintIndex = rnd.Next(hints.Count); //randomizes hints in list

                            string randomString = hints[hintIndex];

                            Console.WriteLine(randomString); //displays a random hint from hint list

                            Console.WriteLine("\nPress enter to return..."); //informs the user to return to the main menu 

                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                }

            } while (runCount > 0); //if attempts are greater than 0, keep running. If at 0, close game 
        }
    }
}
