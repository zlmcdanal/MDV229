using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ZacharyMcDanal_CHT_CodeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string connStr = @"server =192.168.1.234;userid=dbremoteuser;password=root;database=Complete_Hydration_Tracker;port=8889";  //connection to the database
            MySqlConnection conn = new MySqlConnection(connStr);

            conn.Open(); //opening connection

            string userID;

            Console.WriteLine("Welcome to Complete Hydration Tracker!"); //title

            Console.Write("\n\nFor new users, type 'New' or 'Login' for returning users: "); //prompts user to either enter new or login
            string newOrReturn = Console.ReadLine().ToLower();

            if (newOrReturn == "login") //if "login" do this
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Please enter your username and password, then press enter...");
                    Console.Write("\nUsername: ");
                    string userNameInput = Console.ReadLine(); //user enters username and password for his/her account
                    Console.Write("\nPassword: ");
                    string passwordInput = Console.ReadLine();

                    string sql = "SELECT userID FROM Users WHERE username = @username && password = @password"; //checks the database for user's input, if there, get userID
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@username", userNameInput);
                    cmd.Parameters.AddWithValue("@password", passwordInput);

                    MySqlDataReader rdr = cmd.ExecuteReader();

                    rdr.Read();

                    userID = rdr[0].ToString(); //saves userID to variable userID

                    Console.Clear();
                    Console.WriteLine("Welcome " + userNameInput + "!"); //welcomes the user 

                    HydrationControl(userID); //call to HydrationControl function
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Username or password is incorrect - Please start the program again and re-enter the information\n"); //if entry is incorrect, display this
                }
            }

            else if (newOrReturn == "new") //if "new" do this
            {
                Console.WriteLine("Please enter the information below, then press enter...");
                Console.Write("\nEmail: ");
                string emailInput = Console.ReadLine();
                Console.Write("\nUsername: ");
                string userNameInput = Console.ReadLine(); //user fills out information for new user
                Console.Write("\nPassword: ");
                string passwordInput = Console.ReadLine();

                string sql = "INSERT INTO Users (username, password, emailAddress) VALUES (@username, @password, @email)"; //inserts information into database
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@username", userNameInput);
                cmd.Parameters.AddWithValue("@password", passwordInput);
                cmd.Parameters.AddWithValue("@email", emailInput);
                MySqlDataReader rdr = cmd.ExecuteReader();

                conn.Close();
                conn.Open();
                string sql2 = "SELECT userID FROM Users WHERE username = @username2 && password = @password2"; //gathers the userID of the newly created account
                MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@username2", userNameInput);
                cmd2.Parameters.AddWithValue("@password2", passwordInput);
                MySqlDataReader rdr2 = cmd2.ExecuteReader();

                rdr2.Read();
                userID = rdr2[0].ToString(); //stores the userID in the userID variable
                conn.Close();

                Console.Clear();
                Console.WriteLine("Welcome " + userNameInput + "!"); //welcomes the user 

                HydrationControl(userID); //call to HydrationControl function
            }
            else
            {
                Console.WriteLine("Invalid input - Please start the program again and re-enter either 'New' or 'Login'..."); //if neither login or new, display this
            }
        }

        public static void HydrationControl(string userID)
        {
            string connStr = @"server =192.168.1.234;userid=dbremoteuser;password=root;database=Complete_Hydration_Tracker;port=8889"; //connection to database
            MySqlConnection conn = new MySqlConnection(connStr);

            bool running = true; //do while loop bool variable

            do
            {

                Console.WriteLine("Main Menu\n\n"); //main menu screen
            Console.Write("Which would you like to enter?\n" +
            "1. Water Oz\n" +
            "2. Soda Oz\n" +
            "3. Alcohol Oz\n" +
            "4. View Hydration\n" + //hydration menu
            "5. Log Out\n" +
            "Choice: ");

            string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1":
                    case "1.":
                    case "water":
                    case "wateroz": //if user picks to add water
                    case "water oz":
                        {
                            Console.Clear();
                            Console.WriteLine("How many ounces of water have you drank?"); //prompts the user to enter amount drank in oz
                            string ozWater = Console.ReadLine();

                            conn.Open();

                            string sql = "INSERT INTO Hydration (userID, date, hydration) VALUES (@userID, NOW(), @hydration)"; //inserts info into database along with current date
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            cmd.Parameters.AddWithValue("@hydration", ozWater);
                            MySqlDataReader rdr = cmd.ExecuteReader();
                            conn.Close();

                            conn.Open();
                            string sql2 = "SELECT SUM(hydration) FROM Hydration WHERE userID = @userID2 && date = CURDATE()";  //pulls current hydration sum from database based on current date
                            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                            cmd2.Parameters.AddWithValue("@userID2", userID);
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();

                            rdr2.Read();
                            string sum = rdr2[0].ToString();
                            conn.Close();

                            Console.WriteLine("Current Hydration is: " + sum + " oz");
                        }
                        break;
                    case "2":
                    case "2.":
                    case "soda":
                    case "sodaoz": //if user picks to add soda
                    case "soda oz":
                        {
                            Console.Clear();
                            Console.WriteLine("How many ounces of soda have you drank?"); //prompts the user to enter amount drank in oz
                            float soda;
                            float.TryParse(Console.ReadLine(), out soda);
                            Console.Clear();

                            float conversion = soda * -1.5f; //soda hydration conversion

                            conn.Open();

                            string sql = "INSERT INTO Hydration (userID, date, hydration) VALUES (@userID, NOW(), @hydration)"; //inserts info into database along with current date
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            cmd.Parameters.AddWithValue("@hydration", conversion);
                            MySqlDataReader rdr = cmd.ExecuteReader();
                            conn.Close();

                            conn.Open();
                            string sql2 = "SELECT SUM(hydration) FROM Hydration WHERE userID = @userID2 && date = CURDATE()";  //pulls current hydration sum from database based on current date
                            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                            cmd2.Parameters.AddWithValue("@userID2", userID);
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();

                            rdr2.Read();
                            string sum = rdr2[0].ToString();
                            conn.Close();

                            Console.Clear();
                            Console.WriteLine("Current Hydration is: " + sum + " oz"); //displays current hydration sum
                        }
                        break;
                    case "3":
                    case "3.":
                    case "alcohol":
                    case "alcoholoz": //if user picks to add alcoholic beverage
                    case "alcohol oz":
                        {
                            Console.Clear();
                            Console.WriteLine("How many ounces of alcohol have you drank?"); //prompts the user to enter amount drank in oz
                            float alcohol;
                            float.TryParse(Console.ReadLine(), out alcohol);

                            float conversion = alcohol * -4.0f; //alcohol hydration conversion

                            conn.Open();

                            string sql = "INSERT INTO Hydration (userID, date, hydration) VALUES (@userID, NOW(), @hydration)"; //inserts info into database along with current date
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            cmd.Parameters.AddWithValue("@hydration", conversion);
                            MySqlDataReader rdr = cmd.ExecuteReader();
                            conn.Close();

                            conn.Open();
                            string sql2 = "SELECT SUM(hydration) FROM Hydration WHERE userID = @userID2 && date = CURDATE()"; //pulls current hydration sum from database based on current date
                            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                            cmd2.Parameters.AddWithValue("@userID2", userID);
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();

                            rdr2.Read();
                            string sum = rdr2[0].ToString();
                            conn.Close();

                            Console.Clear();
                            Console.WriteLine("Current Hydration is: " + sum + " oz"); //displays current hydration sum
                        }
                        break;
                    case "4":
                    case "4.":
                    case "view hydration": //if user picks to display current hyrdration for the day
                    case "viewhydration":
                        {
                            conn.Open();
                            string sql2 = "SELECT SUM(hydration) FROM Hydration WHERE userID = @userID2 && date = CURDATE()"; //pulls current hydration sum from database based on current date
                            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                            cmd2.Parameters.AddWithValue("@userID2", userID);
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();

                            rdr2.Read();
                            string sum = rdr2[0].ToString();
                            conn.Close();

                            Console.Clear();
                            Console.WriteLine("Current Hydration is: " + sum + " oz"); //displays current hydration sum
                        }
                        break;
                    case "5":
                    case "5.":
                    case "log out": //if user chooses to exit program 
                    case "logout":
                        {
                            running = false;
                        }
                        break;
                    default:
                        {
                            Console.WriteLine("Invalid input - please try again..."); //anything else entered, display this
                        }
                        break;
                }
            } while (running);
        }
    }
}

