using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodingExercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerWins = 0;
            int playerCompTie = 0; //score keepers
            int playerLoses = 0;

            int greenLight = 0; //to exit program greenLight has to equal 1

            int playNumber = 10; //10 plays before results

            Console.WriteLine("Welcome to 'Rock, Paper, Scissors, Lizard, Spock'!\n\n"); //welcome message




            Console.Write("Instructions:\n" +
                "~ Scissors cuts Paper\n" +
                "~ Paper covers Rock\n" +
                "~ Rock crushes Lizard\n" +
                "~ Lizard poisons Spock\n" +
                "~ Spock smashes Scissors\n" + //instructions at the beginning
                "~ Scissors decapitates Lizard\n" +
                "~ Lizard eats Paper\n" +
                "~ Paper disproves Spock\n" +
                "~ Spock vaporizes Rock\n" +
                "~ Rock crushes Scissors\n\n" +
                "If you would like to exit the game at any time - type 'Exit' or 'Quit'\n\n");

            Console.WriteLine("Press enter to play..."); //press enter to start game
            Console.ReadKey();

            do
            {
                if (playNumber == 0)
                {
                    Console.Clear();

                    Console.Write("Score Results:\n\n" +
                        "Player Wins: " + playerWins + "\n" +
                        "Player/Comp Ties: " + playerCompTie + "\n" +  //score results once user plays 10 times
                        "Player Loses: " + playerLoses + "\n" +
                        "\nWould you like to play again??? (Y/N)");

                    string playAgain = Console.ReadLine().ToLower();

                    if (playAgain == "y" || playAgain == "yes") //do this if user types y or yes
                    {
                        Console.Clear();
                        playNumber = 10;
                    }
                    else if (playAgain == "n" || playAgain == "no") //do this if user types n or no
                    {
                        Console.Clear();
                        Console.WriteLine("Thanks for playing!"); 
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Not a valid input. Please try again..."); //if user types anything besides y, yes, n, no - do this
                        continue;
                    }
                }
                

                
                Console.WriteLine("Do you choose Rock, Paper, Scissors, Lizard, or Spock?"); //Main question to user

                string userPick = Console.ReadLine().ToLower();

                Random rnd = new Random();
                int compPick = rnd.Next(5);

                    switch (userPick)
                    {
                        case "rock": //if user picks rock
                        case "1":
                            {
                                if (compPick == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Tie!\nThe Computer picks Rock and so did you! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerCompTie++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //tie
                                }
                                else if (compPick == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Computer Wins!\nThe Computer picks Paper and covers your Rock! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerLoses++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //lose
                                }
                                else if (compPick == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Player Wins!\nThe Computer picks Scissors and is crushed by your Rock! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerWins++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //win
                                }
                                else if (compPick == 3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Player Wins!\nThe Computer picks Lizard and is crushed by your Rock! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerWins++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //win
                                }
                                else if (compPick == 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Computer Wins!\nThe Computer picks Spock and vaporizes your Rock! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerLoses++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //lose
                                }
                                playNumber--; //subtracts 1 playNumber
                        }
                            break;
                        case "paper": //if user picks paper
                        case "2":
                            {
                                if (compPick == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Player Wins!\nThe Computer picks Rock and is covered by your Paper! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerWins++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //win
                                }
                                else if (compPick == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Tie!\nThe Computer picks Paper and so did you! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerCompTie++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //tie
                                }
                                else if (compPick == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Computer Wins!\nThe Computer picks Scissors and cuts your paper! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerLoses++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //lose
                                }
                                else if (compPick == 3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Computer Wins!\nThe Computer picks Lizard and eats your Paper! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerLoses++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //lose
                                }
                                else if (compPick == 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Player Wins!\nThe Computer picks Spock and is disproven by your Paper! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerWins++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //win
                                }
                                playNumber--; //subtracts 1 playNumber
                        }
                            break;
                        case "scissors": //if user picks scissors
                        case "3":
                            {
                                if (compPick == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Computer Wins!\nThe Computer picks Rock and smashes your Scissors! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerLoses++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //lose
                                }
                                else if (compPick == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Player Wins!\nThe Computer picks Paper and is cut by your Scissors! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerWins++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //win
                                }
                                else if (compPick == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Tie!\nThe Computer picks Scissors and so did you! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerCompTie++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //tie
                                }
                                else if (compPick == 3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Player Wins!\nThe Computer picks Lizard and is decapitated by your Scissors! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerWins++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //win
                                }
                                else if (compPick == 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Computer Wins!\nThe Computer picks Spock and smashes your Scissors! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerLoses++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //lose
                                }
                                playNumber--; //subtracts 1 playNumber
                        }
                            break;
                        case "lizard": //if user picks lizard
                        case "4":
                            {
                                if (compPick == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Computer Wins!\nThe Computer picks Rock and crushes your Lizard! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerLoses++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //lose
                                }
                                else if (compPick == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Player Wins!\nThe Computer picks Paper and is eaten by your Lizard! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerWins++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //win
                                }
                                else if (compPick == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Computer Wins!\nThe Computer picks Scissors and decapitates your Lizard! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerLoses++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //lose
                                }
                                else if (compPick == 3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Tie!\nThe Computer picks Lizard and so did you! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerCompTie++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //tie
                                }
                                else if (compPick == 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Player Wins!\nThe Computer picks Spock and is poisoned by your Lizard! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerWins++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //win
                                }
                                playNumber--; //subtracts 1 playNumber
                        }
                            break;
                        case "spock": //if user picks spock
                        case "5":
                            {
                                if (compPick == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Player Wins!\nThe Computer picks Rock and is vaporized by your Spock! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerWins++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //win
                                }
                                else if (compPick == 1)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Computer Wins!\nThe Computer picks Paper and disproves your Spock! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerLoses++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //lose
                                }
                                else if (compPick == 2)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Player Wins!\nThe Computer picks Scissors and is smashed by your Spock! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerWins++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //win
                                }
                                else if (compPick == 3)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Computer Wins!\nThe Computer picks Lizard and poisons your Spock! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerLoses++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //lose
                                }
                                else if (compPick == 4)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Tie!\nThe Computer picks Spock and so do you! Matches remaining: " + (playNumber - 1)); //single game result to user + playNumbers remaining
                                    playerCompTie++;
                                    Console.ReadKey();
                                    Console.Clear();
                                    //tie
                                }
                                playNumber--; //subtracts 1 playNumber
                            }
                            break;
                        case "exit":
                        case "quit": //user can quit the program by typing either exit or quit
                            {
                                greenLight = 1; 
                            }
                            break;
                        default:
                            {
                                Console.WriteLine("Not a valid input"); //if user types something other than the various choices, display this
                            }
                            break;
                    }
                
            } while (greenLight < 1); //play until greenLight equals 1
        }
    }
}
