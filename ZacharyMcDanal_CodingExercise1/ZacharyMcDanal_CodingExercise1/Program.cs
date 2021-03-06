﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodingExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var clothingBrands = new List<string> {"Prada", "Vans", "Old Navy", "Levi", "Hollister", "American Eagle", "Victoria Secret", "Forever 21", "Kate Spade", "Gucci", "Buckle", "Pink", "Nike", "Adidas", "Wrangler", "Mossimo", "Cat & Jack", "Sundance", "Under Armour", "Lucky" };
            // list of 20 items 

            bool running = true; //bool statment used to exit from menu

            do
            {
                Console.Write("Please select from the following:\n" +    //user menu. Here the user will make his/her switch choice
                    "1. Alphabetize the clothing brands (A-Z)\n" +
                    "2. Alphabetize the clothing brands (Z-A)\n" +
                    "3. Randomly delete a brand from the list\n" +
                    "4. Exit\n" +
                    "Choice: ");

                string choice = Console.ReadLine().ToLower();

                switch (choice) //switch begins 
                {
                    case "1":
                    case "alphabetize the clothing brands (a-z)": //swtich choice to alphabetize items in clothingBrands a-z
                        {
                            Console.Clear();

                            int lineNumber = 1;

                            clothingBrands.Sort(); //alphabetizes items in clothingBrand

                            foreach(string brand in clothingBrands) //loops through items in clothingBrands and displays them
                            {
                                Console.WriteLine(lineNumber + ". " + brand);
                                lineNumber++;
                            }

                            Console.Write("\nPress enter to return to the main menu..."); //Promts the user to press enter to return to main menu
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "2":
                    case "alphabetize the clothing brands (z-a)": //switch choice to alphabetize items in clothingBrands backwards
                        {
                            Console.Clear();

                            int lineNumber = 1;

                            clothingBrands.Sort(); //alphabetical order
                            clothingBrands.Reverse(); //reverses the order to display z-a

                            foreach (string brand in clothingBrands)  //loops through each item in clothingBrands and displays them along side a line number
                            {
                                Console.WriteLine(lineNumber + ". " + brand);
                                lineNumber++;
                            }

                            Console.Write("\nPress enter to return to the main menu..."); //Promts the user to press enter to return to main menu
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case "3":
                    case "randomly delete a brand from the list":  //switch choice to delete random item
                        {
                            Console.Clear();

                            int lineNumber = 1;

                            foreach (string brand in clothingBrands) //loops through items in clothingBrand list and displays items
                            {
                                Console.WriteLine(lineNumber + ". " + brand);
                                lineNumber++;
                            }

                            Console.Write("\nPress enter to randomly delete a brand from the list..."); //asks the user to press enter to delete random item
                            Console.ReadKey();

                            Random rnd = new Random();

                            int index = rnd.Next(0, clothingBrands.Count - 1);

                            Console.WriteLine("A random clothing brand was removed from the list.");  //VMware bug - adds .st onto the back of "list"
                            Console.Write("The remaining brands are listed below:\n"); //Build-up to display remaining items

                            clothingBrands.RemoveAt(index);

                            int lineNumber2 = 1;

                            foreach (string brand in clothingBrands)   //loops through items in clothingBrands list and displays remaining list items. Also adds line number
                            {
                                Console.WriteLine(lineNumber2 + ". " + brand);
                                lineNumber2++;
                            }

                            Console.Write("\nPress enter to return to the main menu..."); //Promts the user to press enter to return to main menu
                            Console.ReadKey();
                            Console.Clear();

                        }
                        break;
                    case "4":
                    case "exit": //switch choice to exit menu
                        {
                            running = false; //exit menu
                        }
                        break;
                }
            } while (running); //loops through menu until user exits program
        }
    }
}
