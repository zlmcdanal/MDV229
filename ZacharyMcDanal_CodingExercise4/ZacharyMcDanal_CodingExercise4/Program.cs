using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodingExercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary is created
            Dictionary<string, List<string>> myDictionary = new Dictionary<string, List<string>>();

            //Red list facts
            var red = new List<string> { "It is one of the 3 colors on a traffic light", "It is the color of anger", "It's good for dark room development" };
            myDictionary["red"] = red;

            //Orange list facts
            var orange = new List<string> { "It has the same name as a fruit", "It is the color of the powerpoint logo", "second top highlighter color" };
            myDictionary["orange"] = orange;

            //Yellow list facts
            var yellow = new List<string> { "It is one of the 3 colors on a traffic light", "It is the color of the sun", "It stands for positivity" };
            myDictionary["yellow"] = yellow;

            //Green list facts
            var green = new List<string> { "It generally means 'Go'", "It is one of the 3 colors on a traffic light", "It stands for calmness" };
            myDictionary["green"] = green;

            //Blue list facts
            var blue = new List<string> { "Related to the feeling of sad", "Color of the Ocean", "Is the most common lightsaber color in Star Wars" };
            myDictionary["blue"] = blue;

            //Indigo list facts
            var indigo = new List<string> { "Is close to blue and purple", "Is the true color of a blueberry", "One of the colors of a rainbow" };
            myDictionary["indigo"] = indigo;

            //Violet list facts
            var violet = new List<string> { "It has the shortest wavelength of all the visible colors", "Closer to blue than any other color", "Is not actually purple" };
            myDictionary["violet"] = violet;


            //user menu setup begins

            bool running = true; //bool to exit menu

            do //menu cycle
            {
                Console.WriteLine("Welcome to the Color Dictionary!\n");

                Console.Write("What is your favorite color?\n\n" +   //user menu
                    "~ Red\n" +
                    "~ Orange\n" +
                    "~ Yellow\n" +
                    "~ Green\n" +
                    "~ Blue\n" +
                    "~ Indigo\n" +
                    "~ Violet\n\n" +
                    "~ Exit\n\n" +
                    "Choice: ");

                string choice = Console.ReadLine().ToLower(); //user choice is captured and lowered to lowercase

                switch (choice) //switch begins
                {
                    case "red":
                        {
                            Console.Clear();

                            Console.WriteLine("Facts about the color 'Red':\n"); //Title for color

                            int lineNumber = 1; //linenumber to add neatness 

                            foreach (string item in myDictionary["red"]) //loops through and displays all facts with number beside them
                            {
                                Console.WriteLine(lineNumber + ". " + item + "\n");
                                lineNumber++;
                            }

                            Console.WriteLine("Would you like to choose a different color? (Yes/No)"); //prompts the user if they would like to return to menu

                            string answer = Console.ReadLine().ToLower(); //captures users answer

                            if (answer == "yes") //clears screen and returns to menu
                            {
                                Console.Clear();
                            }
                            else
                            {
                                running = false; //any other user input exits program
                            }
                        }
                        break;
                    case "orange":
                        {
                            Console.Clear();

                            Console.WriteLine("Facts about the color 'Orange':\n"); //Title for color

                            int lineNumber = 1; //linenumber to add neatness 

                            foreach (string item in myDictionary["orange"]) //loops through and displays all facts with number beside them
                            {
                                Console.WriteLine(lineNumber + ". " + item + "\n");
                                lineNumber++;
                            }

                            Console.WriteLine("Would you like to choose a different color? (Yes/No)"); //prompts the user if they would like to return to menu

                            string answer = Console.ReadLine().ToLower(); //captures users answer

                            if (answer == "yes") //clears screen and returns to menu
                            {
                                Console.Clear();
                            }
                            else
                            {
                                running = false; //any other user input exits program
                            }
                        }
                        break;
                    case "yellow":
                        {
                            Console.Clear();

                            Console.WriteLine("Facts about the color 'Yellow':\n"); //Title for color

                            int lineNumber = 1; //linenumber to add neatness 

                            foreach (string item in myDictionary["yellow"]) //loops through and displays all facts with number beside them
                            {
                                Console.WriteLine(lineNumber + ". " + item + "\n");
                                lineNumber++;
                            }

                            Console.WriteLine("Would you like to choose a different color? (Yes/No)"); //prompts the user if they would like to return to menu

                            string answer = Console.ReadLine().ToLower(); //captures users answer

                            if (answer == "yes") //clears screen and returns to menu
                            {
                                Console.Clear();
                            }
                            else
                            {
                                running = false; //any other user input exits program
                            }
                        }
                        break;
                    case "green":
                        {
                            Console.Clear();

                            Console.WriteLine("Facts about the color 'Green':\n"); //Title for color

                            int lineNumber = 1; //linenumber to add neatness 

                            foreach (string item in myDictionary["green"]) //loops through and displays all facts with number beside them
                            {
                                Console.WriteLine(lineNumber + ". " + item + "\n");
                                lineNumber++;
                            }

                            Console.WriteLine("Would you like to choose a different color? (Yes/No)"); //prompts the user if they would like to return to menu

                            string answer = Console.ReadLine().ToLower(); //captures users answer

                            if (answer == "yes") //clears screen and returns to menu
                            {
                                Console.Clear();
                            }
                            else
                            {
                                running = false; //any other user input exits program
                            }
                        }
                        break;
                    case "blue":
                        {
                            Console.Clear();

                            Console.WriteLine("Facts about the color 'Blue':\n"); //Title for color

                            int lineNumber = 1; //linenumber to add neatness 

                            foreach (string item in myDictionary["blue"]) //loops through and displays all facts with number beside them
                            {
                                Console.WriteLine(lineNumber + ". " + item + "\n");
                                lineNumber++;
                            }

                            Console.WriteLine("Would you like to choose a different color? (Yes/No)"); //prompts the user if they would like to return to menu

                            string answer = Console.ReadLine().ToLower(); //captures users answer

                            if (answer == "yes") //clears screen and returns to menu
                            {
                                Console.Clear();
                            }
                            else
                            {
                                running = false; //any other user input exits program
                            }
                        }
                        break;
                    case "indigo":
                        {
                            Console.Clear();

                            Console.WriteLine("Facts about the color 'Indigo':\n"); //Title for color

                            int lineNumber = 1; //linenumber to add neatness 

                            foreach (string item in myDictionary["indigo"]) //loops through and displays all facts with number beside them
                            {
                                Console.WriteLine(lineNumber + ". " + item + "\n");
                                lineNumber++;
                            }

                            Console.WriteLine("Would you like to choose a different color? (Yes/No)"); //prompts the user if they would like to return to menu

                            string answer = Console.ReadLine().ToLower(); //captures users answer

                            if (answer == "yes") //clears screen and returns to menu
                            {
                                Console.Clear();
                            }
                            else
                            {
                                running = false; //any other user input exits program
                            }
                        }
                        break;
                    case "violet":
                        {
                            Console.Clear();

                            Console.WriteLine("Facts about the color 'Violet':\n"); //Title for color

                            int lineNumber = 1; //linenumber to add neatness 

                            foreach (string item in myDictionary["violet"]) //loops through and displays all facts with number beside them
                            {
                                Console.WriteLine(lineNumber + ". " + item + "\n");
                                lineNumber++;
                            }

                            Console.WriteLine("Would you like to choose a different color? (Yes/No)"); //prompts the user if they would like to return to menu

                            string answer = Console.ReadLine().ToLower(); //captures users answer

                            if (answer == "yes") //clears screen and returns to menu
                            {
                                Console.Clear();
                            }
                            else
                            {
                                running = false; //any other user input exits program
                            }
                        }
                        break;
                    case "exit":
                        {
                            Console.Clear();

                            Console.WriteLine("Goodbye!"); // final farewell

                            running = false; //stops program
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid input - Please choose a color that is listed"); // in case user enters anything else
                        }
                        break;
                }

            } while (running); //loops while running = true;
        }
    }
}
