using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace ZacharyMcDanal_CodeFiles
{
    class Program
    {

        public static string connStr = @"server = 192.168.1.234;userid=dbremoteuser;password=root;database=ZacharyMcDanal_MDV229_Database_201902;port=8889"; //call to the database
        public static MySqlConnection conn = new MySqlConnection(connStr);

        public static List<Dates> date = new List<Dates>(); //list of dates
        public static List<Activity> actList = new List<Activity>(); //list for activities
        public static List<ActivityDescription> actDescList = new List<ActivityDescription>(); //list of descriptions
        public static List<string> days = new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" }; //list of all days in specific order
        public static List<Length> actLength = new List<Length>(); //list of all activity times
        public static List<ViewByDate> specificViewByDate = new List<ViewByDate>(); //holds the values pulled from SpecificDatePull
        public static List<ViewByCat> specificViewByCat = new List<ViewByCat>(); //holds the values pulled from SpecificCatPull
        public static List<ViewByDesc> specificViewByDesc = new List<ViewByDesc>(); //holds the values pulled from SpecificDescPull
        public static List<double> timeSpentTotal = new List<double>(); //holds total for time spent over the course

        public static void activity_category()
        {
            try
            {
                conn.Open();

                string activ = "SELECT activity_category_id, category_description FROM activity_categories ORDER BY activity_category_id";

                MySqlCommand cmd = new MySqlCommand(activ, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int actID = (int)rdr[0];
                    string act = rdr[1].ToString();
                    Activity activity = new Activity(actID, act);
                    actList.Add(activity);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        } //gathers all categories

        public static void activity_description()
        {
            try
            {
                conn.Open();

                string activDesc = "SELECT activity_description_id, activity_description FROM activity_descriptions ORDER BY activity_description_id";

                MySqlCommand cmd = new MySqlCommand(activDesc, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int actDescID = (int)rdr[0];
                    string actDesc = rdr[1].ToString();
                    ActivityDescription activityDesc = new ActivityDescription(actDescID, actDesc);
                    actDescList.Add(activityDesc);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            
        } //gathers all descriptions

        public static void calendar_date()
        {
            try
            {
                conn.Open();

                string dates = "SELECT calendar_date_id, calendar_date FROM tracked_calendar_dates ORDER BY calendar_date_id";

                MySqlCommand cmd = new MySqlCommand(dates, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int calDateID = (int)rdr[0];
                    DateTime calDate = (DateTime)rdr[1];
                    Dates Date = new Dates(calDateID, calDate);
                    date.Add(Date);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        } //gathers all dates

        public static void activity_time()
        {
            conn.Close();
            try
            {
                conn.Open();
                string activ = "SELECT activity_time_id, time_spent_on_activity FROM activity_times ORDER BY activity_time_id";

                MySqlCommand cmd = new MySqlCommand(activ, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int actTimeID = (int)rdr[0];
                    string actTime = rdr[1].ToString();
                    Length length = new Length(actTimeID, actTime);
                    actLength.Add(length);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        } //gathers all activity times

        public static void SpecificDatePull(int calDateID, string userID)
        {
            specificViewByDate.Clear();
            conn.Close();
            try
            {
                conn.Open();
                string specDate = "SELECT activity_categories.category_description, activity_descriptions.activity_description, activity_times.time_spent_on_activity FROM activity_log JOIN tracked_calendar_dates ON activity_log.calendar_date =tracked_calendar_dates.calendar_date_id JOIN activity_categories ON activity_log.category_description = activity_categories.activity_category_id JOIN activity_descriptions ON activity_log.activity_description = activity_descriptions.activity_description_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_log.calendar_date = @calendarDateID && activity_log.user_id = @userID";
                MySqlCommand cmd = new MySqlCommand(specDate, conn);
                cmd.Parameters.AddWithValue("@calendarDateID", calDateID);
                cmd.Parameters.AddWithValue("@userID", userID);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    string specificActivCat = rdr[0].ToString();
                    string specificActivDesc = rdr[1].ToString();
                    double specificActivTime = (double) rdr[2];
                    ViewByDate viewByDate = new ViewByDate(specificActivCat, specificActivDesc, specificActivTime);
                    specificViewByDate.Add(viewByDate);
                    timeSpentTotal.Add(specificActivTime);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();

        } //pulls info based on Date
        public static void SpecificCatPull(int catID, string userID)
        {
            specificViewByCat.Clear();

            conn.Close();
            try
            {
                conn.Open();
                string specCat = "SELECT tracked_calendar_dates.calendar_date, activity_descriptions.activity_description, activity_times.time_spent_on_activity FROM activity_log JOIN tracked_calendar_dates ON activity_log.calendar_date =tracked_calendar_dates.calendar_date_id JOIN activity_categories ON activity_log.category_description = activity_categories.activity_category_id JOIN activity_descriptions ON activity_log.activity_description = activity_descriptions.activity_description_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_categories.activity_category_id = @catID && activity_log.user_id = @userID";
                MySqlCommand cmd = new MySqlCommand(specCat, conn);
                cmd.Parameters.AddWithValue("@catID", catID);
                cmd.Parameters.AddWithValue("@userID", userID);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DateTime specificDate = (DateTime)rdr[0];
                    string specificActivDesc = rdr[1].ToString();
                    double specificActivTime = (double)rdr[2];
                    ViewByCat viewByCat = new ViewByCat(specificDate, specificActivDesc, specificActivTime);
                    specificViewByCat.Add(viewByCat);
                    timeSpentTotal.Add(specificActivTime);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        } //pulls info based on Category
        public static void SpecificDescPull(int descID, string userID)
        {
            specificViewByDesc.Clear();

            conn.Close();
            try
            {
                conn.Open();
                string specDesc = "SELECT tracked_calendar_dates.calendar_date, activity_categories.category_description, activity_times.time_spent_on_activity FROM activity_log JOIN tracked_calendar_dates ON activity_log.calendar_date =tracked_calendar_dates.calendar_date_id JOIN activity_categories ON activity_log.category_description = activity_categories.activity_category_id JOIN activity_descriptions ON activity_log.activity_description = activity_descriptions.activity_description_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_descriptions.activity_description_id = @descID && activity_log.user_id = @userID";
                MySqlCommand cmd = new MySqlCommand(specDesc, conn);
                cmd.Parameters.AddWithValue("@descID", descID);
                cmd.Parameters.AddWithValue("@userID", userID);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DateTime specificDate = (DateTime)rdr[0];
                    string specificActivCat = rdr[1].ToString();
                    double specificActivTime = (double)rdr[2];
                    ViewByDesc viewByDesc = new ViewByDesc(specificDate, specificActivCat, specificActivTime);
                    specificViewByDesc.Add(viewByDesc);
                    timeSpentTotal.Add(specificActivTime);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
        } //pulls info based on Description

        public static int returnMessage = 0; //return message which gets set to 1 in below method
        public static bool running = true;
        public static void Title() //displays the title and color dividers
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("=========================================================================");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(" _____ ___ __  __ _____   _____ ____      _    ____ _  _______ ____       ");
            Console.WriteLine("|_   _|_ _|  \\/  | ____| |_   _|  _ \\    / \\  / ___| |/ / ____|  _ \\      ");
            Console.WriteLine("  | |  | || |\\/| |  _|     | | | |_) |  / _ \\| |   | ' /|  _| | |_) |     ");
            Console.WriteLine("  | |  | || |  | | |___    | | |  _ <  / ___ \\ |___| . \\| |___|  _ <      ");
            Console.WriteLine("  |_| |___|_|  |_|_____|   |_| |_| \\_\\/_/   \\_\\____|_|\\_\\_____|_| \\_\\     ");
            Console.WriteLine("                                                                          ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("=========================================================================");
            Console.ResetColor();
        }

        public static void ColoredDividers() //colors my line dividers
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("=========================================================================");
            Console.ResetColor();
        }


        static void Main(string[] args)
        {

            

            string userID;

            Title();

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine(); //user inputs
            Console.Write("Password: ");
            string passWord = Console.ReadLine();

            conn.Open();//connection open

            try
            {
                string sql = "SELECT user_id FROM time_tracker_users WHERE user_firstname = @firstname && user_lastname = @lastname && user_password = @password";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@firstname", firstName);
                cmd.Parameters.AddWithValue("@lastname", lastName); //checks the database for user inputs and passes if correct
                cmd.Parameters.AddWithValue("@password", passWord);

                MySqlDataReader rdr = cmd.ExecuteReader();

                rdr.Read();

                userID = rdr[0].ToString();
                rdr.Close();
                conn.Close();

                Console.Clear();

                MainMenu(userID, firstName);
                
            }
            catch (Exception)
            {
                Console.Clear();
                Title();
                Console.WriteLine("Username or password is incorrect - Please start the program again and re-enter the information\n"); //if incorrect login info, prompts the user to restart program and try again.
                Console.ReadKey(); //exits the program if user login is incorrect 
                running = false;
            }
            conn.Close();
        }

        public static void MainMenu(string userID, string firstName)
        {
            activity_description();
            activity_category();
            activity_time();
            calendar_date();

            bool running = true;
            do //Loops the menu
            {
                Title();


                Console.Write("Main Menu\n");
                ColoredDividers();

                Console.Write("\n" + //Main Menu
                    "[1] Enter Activity\n" +
                    "[2] View Tracked Data\n" +
                    "[3] Run Calculations\n\n" +
                    "[0] Exit\n");


                ColoredDividers();
                if (returnMessage == 0) //return message if 0
                {
                    Console.WriteLine("Welcome " + firstName); //Welcomes the user
                }
                else //return message when its set to 1
                {
                    Console.WriteLine("The activity has successfully been added.");
                }

                Console.Write("\n\nSelection: "); //User types choice next to this line

                string selection = Console.ReadLine().ToLower(); //captures user's choice and turns it into lowercase

                switch (selection) //switch begins
                {
                    case "[1]":
                    case "1": //choice to enter an activity
                    case "enter activity":
                        {
                            SelectActivity(userID); //call to SelectActivity method
                        }
                        break;
                    case "[2]":
                    case "2": //choice to view tacked data
                    case "view tracked data":
                        {
                            ViewTrackedData(userID); //call to ViewTrackedData method
                        }
                        break;
                    case "[3]":
                    case "3": //choice to run calculations
                    case "run calculations":
                        {
                            RunCalculations(userID); //call to RunCalculations method
                        }
                        break;
                    case "[0]": //choice to exit program
                    case "0":
                    case "exit":
                        {
                            running = false;
                        }
                        break;
                    default:
                        {
                            Console.Clear();

                            Console.WriteLine("Not a valid input - Please try again");
                        }
                        break;
                }
            } while (running); //loops menu if running = true
        }

        public static void SelectActivity(string userID) //SelectActivity Method
        {
            Console.Clear();
            Title(); //displays the title graphic

            Console.WriteLine("Enter Activity\n\n" +
                " [0] Exit");

            ColoredDividers();


            foreach (Activity item in actList) //displays all items in actList list
            {
                Console.WriteLine(item);
            }
            ColoredDividers();

            Console.Write("Select A Category: ");

            int activityChoice;
            while (!int.TryParse(Console.ReadLine(), out activityChoice))
            {
                Console.WriteLine("Not a valid input...");
            }

            if (activityChoice == 0)
            {
                Console.Clear();
                return;
            }
            else
            {
                Console.Clear();
                Title(); //displays the title graphic

                Console.WriteLine("Enter Activity\n\n" +
                    " [0] Exit");
                ColoredDividers();


                foreach (ActivityDescription item in actDescList) //displays all items in actDescList list
                {
                    Console.WriteLine(item);
                }
                ColoredDividers();

                Console.Write("Select A Description: ");

                int descriptionChoice;
                while (!int.TryParse(Console.ReadLine(), out descriptionChoice))
                {
                    Console.WriteLine("Not a valid input...");
                }

                if (descriptionChoice == 0)
                {
                    Console.Clear();
                    return;
                }
                else
                {
                    Console.Clear();
                    Title(); //displays the title graphic

                    Console.WriteLine("Enter Activity\n\n" +
                        " [0] Exit");
                    ColoredDividers();



                    foreach (Dates item in date) //displays all items in date list
                    {
                        Console.WriteLine(item);
                    }
                    ColoredDividers();

                    Console.Write("Select A Date: ");

                    int dateChoice;
                    while(!int.TryParse(Console.ReadLine(), out dateChoice))
                    {
                        Console.WriteLine("Not a valid input...");
                    }

                    if (dateChoice == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    else
                    {
                        Console.Clear();
                        Title(); //displays the title graphic

                        Console.WriteLine("Enter Activity\n\n" +
                            " [0] Exit");
                        ColoredDividers();

                        int lineNumber = 1;

                        for (int i = 0; i < days.Count; i++)
                        {
                            Console.WriteLine("[" + lineNumber + "] " + days[i]);
                            lineNumber++;
                        }

                        ColoredDividers();

                        Console.Write("Select A Day: ");

                        int dayChoice;
                        while(!int.TryParse(Console.ReadLine(), out dayChoice))
                        {
                            Console.WriteLine("Not a valid input...");
                        }

                        if (dayChoice == 0)
                        {
                            Console.Clear();
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Title(); //displays the title graphic

                            Console.WriteLine("Enter Activity\n\n" +
                                " [0] Exit");
                            ColoredDividers();

                            foreach (Length item in actLength) //displays all items in actLength list
                            {
                                Console.WriteLine(item);
                            }
                            ColoredDividers();

                            Console.Write("How long did you perform that activity? ");

                            int lengthChoice;
                            while(!int.TryParse(Console.ReadLine(), out lengthChoice))
                            {
                                Console.WriteLine("Not a valid input...");
                            }

                            if (lengthChoice == 0)
                            {
                                Console.Clear();
                                return;
                            }
                            else
                            {
                                Console.Clear();
                                try
                                {
                                    conn.Open();

                                    string sql = "INSERT INTO activity_log (user_id, calendar_day, calendar_date, day_name, category_description, activity_description, time_spent_on_activity) VALUES (@userID, @calendarDayID, @calendarDateID, @dayNameID, @catDescriptionID, @actDescriptionID, @timeSpentID)";
                                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                                    cmd.Parameters.AddWithValue("@userID", userID);
                                    cmd.Parameters.AddWithValue("@calendarDayID", dateChoice);
                                    cmd.Parameters.AddWithValue("@calendarDateID", dateChoice); //inserts all user choices in database 
                                    cmd.Parameters.AddWithValue("@dayNameID", dayChoice);
                                    cmd.Parameters.AddWithValue("@catDescriptionID", activityChoice);
                                    cmd.Parameters.AddWithValue("@actDescriptionID", descriptionChoice);
                                    cmd.Parameters.AddWithValue("@timeSpentID", lengthChoice);
                                    MySqlDataReader rdr = cmd.ExecuteReader();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.ToString());
                                }
                                conn.Close();

                                returnMessage = 1; //changes returnMessage at main menu - home screen
                                return;
                            }
                        }
                    }
                }
            }
        }
        
        public static void ViewTrackedData (string userID) //View Tracked Data Method
        {
            Console.Clear();
            Title(); //displays the title graphic

            do
            {
                Console.Write("View Tracked Data\n");
                ColoredDividers();
                Console.Write("[1] View By Date\n" +
                    "[2] View By Category\n" +  //menu
                    "[3] View By Description\n\n" +
                    "[0] Main Menu\n");
                ColoredDividers();
                Console.Write("Selection: ");

                string selection = Console.ReadLine().ToLower(); //captures user's selection

                switch (selection)
                {
                    case "1":
                    case "view by date":
                    case "1 view by date": //choice to view everything based on date
                    case "[1] view by date":
                        {
                            timeSpentTotal.Clear(); //clears the timeSpentTotal list to start new

                            Console.Clear();
                            Title(); //displays the title graphic

                            Console.WriteLine("View By Date:\n");
                            Console.WriteLine("[0] Exit");
                            ColoredDividers(); //displays a colored divider

                            foreach (Dates item in date)
                            {
                                Console.WriteLine(item);
                            }
                            ColoredDividers(); //displays a colored divider
                            Console.Write("Select Date: ");

                            int dateSelection;
                            while(!int.TryParse(Console.ReadLine(), out dateSelection))
                            {
                                Console.WriteLine("Please enter a number selection...");
                            }
                            Console.Clear();
                            SpecificDatePull(dateSelection, userID); //call to SpecificDatePull method with two added parameters 

                            Title(); //displays the title graphic

                            Console.WriteLine("ACCORDING TO THE SELECTED DATE:\n");
                            string format = "";
                            format += string.Format("{0, -30} {1,-30} {2, -5}", "#  Category", "    Activity", "Time Spent"); //labels above the listed items

                            Console.WriteLine(format);
                            Console.WriteLine("---------------------------------------------------------------------------------"); //simple line divider
                            int lineNumber = 1;
                            foreach(ViewByDate items in specificViewByDate) //displays a increasing line number along with items in specificViewByDate list
                            {
                                Console.WriteLine("[" + lineNumber + "] " + items);
                                lineNumber++;
                            }
                            Console.WriteLine("---------------------------------------------------------------------------------"); //simple line divider
                            double Total = 0;
                            foreach (double item in timeSpentTotal)
                            {
                                Total += item;
                            }
                            Console.WriteLine("Activity Time Tracked: " + Total + " hours");
                            ColoredDividers(); //displays a colored divider

                        }
                        break;
                    case "2":
                    case "view by category":
                    case "2 view by category": //choice to view everything based on category
                    case "[2] view by category":
                        {
                            timeSpentTotal.Clear(); //clears the timeSpentTotal list to start new

                            Console.Clear();
                            Title(); //displays the title graphic

                            Console.WriteLine("View By Category:\n");
                            Console.WriteLine("[0] Exit\n");
                            ColoredDividers(); //displays a colored divider

                            foreach (Activity item in actList)
                            {
                                Console.WriteLine(item);
                            }
                            ColoredDividers(); //displays a colored divider
                            Console.Write("Select Category: ");

                            int catSelection;
                            while (!int.TryParse(Console.ReadLine(), out catSelection))
                            {
                                Console.WriteLine("Please enter a number selection...");
                            }
                            Console.Clear();
                            SpecificCatPull(catSelection, userID); //call to SpecificCatPull method with two added parameters 

                            Title();//displays the title graphic

                            Console.WriteLine("ACCORDING TO THE SELECTED CATEGORY:\n");
                            string format = "";
                            format += string.Format("{0, -30} {1,-30} {2, -5}", "#  Date", "    Activity", "Time Spent"); //labels above the listed items

                            Console.WriteLine(format);
                            Console.WriteLine("---------------------------------------------------------------------------------"); //simple line divider
                            int lineNumber = 1;
                            foreach (ViewByCat items in specificViewByCat)
                            {
                                Console.WriteLine("[" + lineNumber + "] " + items); //displays a increasing line number along with items in specificViewByCat list
                                lineNumber++;
                            }
                            Console.WriteLine("---------------------------------------------------------------------------------"); //simple line divider
                            double Total = 0;
                            foreach (double item in timeSpentTotal)
                            {
                                Total += item;
                            }
                            Console.WriteLine("Category Time Total: " + Total + " hours");
                            ColoredDividers(); //displays a colored divider
                        }
                        break;
                    case "3":
                    case "view by description":
                    case "3 view by description": //choice to view everything based on description
                    case "[3] view by description":
                        {
                            timeSpentTotal.Clear(); //clears the timeSpentTotal list to start new

                            Console.Clear();
                            Title(); //displays the title graphic

                            Console.WriteLine("View By Description:\n"); 
                            ColoredDividers(); //displays a colored divider
                            
                            foreach (ActivityDescription item in actDescList)
                            {
                                Console.WriteLine(item);
                            }
                            ColoredDividers(); //displays a colored divider
                            Console.Write("Select Description: ");

                            int DescSelection;
                            while (!int.TryParse(Console.ReadLine(), out DescSelection))
                            {
                                Console.WriteLine("Please enter a number selection...");
                            }
                            Console.Clear();
                            SpecificDescPull(DescSelection, userID); //call to SpecificDescPull method with two added parameters 

                            Title(); //displays the title graphic

                            Console.WriteLine("ACCORDING TO THE SELECTED DESCRIPTION:\n");
                            string format = "";
                            format += string.Format("{0, -30} {1,-30} {2, -5}", "#  Date", "    Category", "Time Spent"); //labels above the listed items

                            Console.WriteLine(format);
                            Console.WriteLine("---------------------------------------------------------------------------------"); //simple line divider
                            int lineNumber = 1;
                            foreach (ViewByDesc items in specificViewByDesc)
                            {
                                Console.WriteLine("[" + lineNumber + "] " + items); //displays a increasing line number along with items in specificViewByDesc list
                                lineNumber++;
                            }
                            Console.WriteLine("---------------------------------------------------------------------------------"); //simple line divider
                            double Total = 0;
                            foreach (double item in timeSpentTotal)
                            {
                                Total += item;
                            }
                            Console.WriteLine("Category Time Total: " + Total + " hours");
                            ColoredDividers(); //displays a colored divider
                        }
                        break;
                    case "0":
                    case "main menu":
                    case "0 main menu": //choice to view the main menu
                    case "[0] main menu":
                        {
                            Console.Clear();
                            returnMessage = 0;
                            return;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Not a valid input - Please try again");
                        }
                        break;

                }

            } while (running);
        }

        public static void RunCalculations(string userID) //run calculations method
        {
            string displayThis = null; //string that displays below calculations menu
            

            do //loops through the switch as long as running = true
            {
                Console.Clear();
                Title(); //call to title logo

                Console.Write("Calculations:\n");
                ColoredDividers();
                Console.Write("[1] Time Spent Sleeping\n" +
                    "[2] Time With Kids\n" +
                    "[3] Total Time Spent with Parents\n" +
                    "[4] Total Time Awake\n" +
                    "[5] Percent of Time Sleeping\n" +
                    "[6] Total Time with Girlfriend Watching Tv\n" + //calculations menu
                    "[7] Total Time Chilling\n" +
                    "[8] Total Time Cooking\n" +
                    "[9] Total Time Sleeping\n" +
                    "[10] Percent of Time Brewing Beer\n\n" +
                    "[0] Main Menu\n");
                if (displayThis == null) //display basically nothing if displayThis = null
                {
                    ColoredDividers();
                    Console.Write("Selection: ");
                }
                else //display this if displayThis has been given a string value
                {
                    ColoredDividers();
                    Console.WriteLine(displayThis);
                    ColoredDividers();
                    Console.Write("Selection: ");
                }

                string selection = Console.ReadLine().ToLower(); //captures the user's menu input

                switch (selection)
                {
                    case "1":
                    case "time spent sleeping": //calc the time spent sleeping
                    case "1 time spent sleeping":
                    case "[1]":
                    case "[1] time spent sleeping":
                        {
                            conn.Open();
                            string sql = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_descriptions ON activity_log.activity_description = activity_descriptions.activity_description_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_descriptions.activity_description_id = 4 && user_id = @userID";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            rdr.Read();
                                
                            string sum = rdr[0].ToString();
                                
                            rdr.Close();
                           
                            conn.Close();

                            Console.Clear();
                            displayThis = ("[1] Total time spent sleeping in 26 days: " + sum + " hours"); //adds a value to displayThis
                            
                        }
                        break;
                    case "2":
                    case "time with kids":
                    case "2 time with kids": //calc the time spent with the kids
                    case "[2]":
                    case "[2] time with kids":
                        {
                            conn.Open();
                            string sql = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_categories ON activity_log.category_description = activity_categories.activity_category_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_categories.activity_category_id = 10 && user_id = @userID";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            rdr.Read();

                            string sum = rdr[0].ToString();

                            rdr.Close();

                            conn.Close();

                            Console.Clear();
                            displayThis = ("[2] Total time spent with the kids in 26 days: " + sum + " hours"); //adds a value to displayThis
                        }
                        break;
                    case "3":
                    case "total time spent with parents":
                    case "3 total time spent with parents": //calcs the total time spent with parents
                    case "[3]":
                    case "[3] total time spent with parents":
                        {
                            conn.Open();
                            string sql = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_categories ON activity_log.category_description = activity_categories.activity_category_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_categories.activity_category_id = 7 && user_id = @userID";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            rdr.Read();

                            string sum = rdr[0].ToString();

                            rdr.Close();

                            conn.Close();

                            Console.Clear();
                            displayThis = ("[3] Total time spent visiting parents in 26 days: " + sum + " hours"); //adds a value to displayThis
                        }
                        break;
                    case "4":
                    case "total time awake":
                    case "4 total time awake":  //calcs the total time spent awake
                    case "[4]":
                    case "[4] total time awake":
                        {
                            
                            conn.Open();
                            string sql = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_categories ON activity_log.category_description = activity_categories.activity_category_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_categories.activity_category_id = 4 && activity_log.user_id = @userID";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            rdr.Read();

                            double sumOfSleepHours = (double) rdr[0]; //first sql pull

                            rdr.Close();
                            
                            conn.Close();
                            conn.Open();
                            string sql2 = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_log.user_id = @userID2";
                            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                            cmd2.Parameters.AddWithValue("@userID2", userID);
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();

                            rdr2.Read();

                            double sumOfTotalHours = (double)rdr2[0]; //second sql pull

                            rdr2.Close();
                           
                            conn.Close();
                            double sumOfTimeAwake = sumOfTotalHours - sumOfSleepHours; //calc to find total of time awake
                            Console.Clear();

                            displayThis = ("[4] Total time spent awake in 26 days: " + sumOfTimeAwake + " hours"); //adds a value to displayThis

                        }
                        break;
                    case "5":
                    case "percent of time sleeping":
                    case "5 percent of time sleeping": //calcs the total percent of time spent sleeping
                    case "[5]":
                    case "[5] percent of time sleeping":
                        {
                            conn.Open();
                            string sql = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_descriptions ON activity_log.activity_description = activity_descriptions.activity_description_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_descriptions.activity_description_id = 4 && user_id = @userID";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            rdr.Read();

                            double sumOfTimeSleeping = (double)rdr[0]; //first sql pull

                            rdr.Close();

                            conn.Close();
                            conn.Open();
                            string sql2 = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_log.user_id = @userID2";
                            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                            cmd2.Parameters.AddWithValue("@userID2", userID);
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();

                            rdr2.Read();

                            double sumOfTotalHours = (double)rdr2[0]; //second sql pull

                            rdr2.Close();

                            conn.Close();
                            double percentStep1 = sumOfTimeSleeping / sumOfTotalHours; //first step is division to find the decimal amount
                            string percentStep2 = (percentStep1.ToString("P1", CultureInfo.InvariantCulture)); //converts that said decimal amount into a string percentage 

                            Console.Clear();
                            displayThis = ("[5] Total percent of time spent sleeping in 26 days: " + percentStep2); //adds a value to displayThis
                        }
                        break;
                    case "6":
                    case "total time with girlfriend watching tv":
                    case "6 total time with girlfriend watching tv": //calcs the total time with girlfriend watching tv
                    case "[6]":
                    case "[6] total time with girlfriend watching tv":
                        {
                            conn.Open();
                            string sql = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_descriptions ON activity_log.activity_description = activity_descriptions.activity_description_id JOIN activity_categories ON activity_log.category_description = activity_categories.activity_category_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_categories.activity_category_id = 8 && activity_descriptions.activity_description_id = 5 && user_id = @userID";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            rdr.Read();

                            string sum = rdr[0].ToString();

                            rdr.Close();

                            conn.Close();

                            Console.Clear();
                            displayThis = ("[6] Total time spent with the girlfriend watching tv in 26 days: " + sum + " hours"); //adds a value to displayThis
                        }
                        break;
                    case "7":
                    case "total time chilling":
                    case "7 total time chilling": //calcs the total time chilling
                    case "[7]":
                    case "[7] total time chilling":
                        {
                            conn.Open();
                            string sql = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_categories ON activity_log.category_description = activity_categories.activity_category_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_categories.activity_category_id = 5 && user_id = @userID";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            rdr.Read();

                            string sum = rdr[0].ToString();

                            rdr.Close();

                            conn.Close();

                            Console.Clear();
                            displayThis = ("[7] Total time spent just chilling in 26 days: " + sum + " hours"); //adds a value to displayThis
                        }
                        break;
                    case "8":
                    case "total time cooking":
                    case "8 total time cooking": //calcs the total time cooking
                    case "[8]":
                    case "[8] total time cooking":
                        {
                            conn.Open();
                            string sql = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_categories ON activity_log.category_description = activity_categories.activity_category_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_categories.activity_category_id = 9 && user_id = @userID";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            rdr.Read();

                            string sum = rdr[0].ToString();

                            rdr.Close();

                            conn.Close();

                            Console.Clear();
                            displayThis = ("[8] Total time spent cooking in 26 days: " + sum + " hours"); //adds a value to displayThis
                        }
                        break;
                    case "9":
                    case "total time sleeping":
                    case "9 total time sleeping": //calcs the total time sleeping
                    case "[9]":
                    case "[9] total time sleeping":
                        {
                            conn.Open();
                            string sql = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_categories ON activity_log.category_description = activity_categories.activity_category_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_categories.activity_category_id = 4 && activity_log.user_id = @userID";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            rdr.Read();

                            double sum = (double)rdr[0];

                            rdr.Close();

                            conn.Close();

                            Console.Clear();
                            displayThis = ("[9] Total time spent sleeping in 26 days: " + sum + " hours"); //adds a value to displayThis
                        }
                        break;
                    case "10":
                    case "percent of time brewing beer":
                    case "10 percent of time brewing beer": //calcs the total percentage of the time spent brewing 
                    case "[10]":
                    case "[10] percent of time brewing beer":
                        {
                            conn.Open();
                            string sql = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_descriptions ON activity_log.activity_description = activity_descriptions.activity_description_id JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_descriptions.activity_description_id = 2 && activity_log.user_id = @userID";
                            MySqlCommand cmd = new MySqlCommand(sql, conn);
                            cmd.Parameters.AddWithValue("@userID", userID);
                            MySqlDataReader rdr = cmd.ExecuteReader();

                            rdr.Read();

                            double sumOfTotalHoursBrewing = (double)rdr[0]; //sql pull
                            
                            rdr.Close();

                            conn.Close();
                            conn.Open();
                            string sql2 = "SELECT SUM(activity_times.time_spent_on_activity) FROM activity_log JOIN activity_times ON activity_log.time_spent_on_activity = activity_times.activity_time_id WHERE activity_log.user_id = @userID2";
                            MySqlCommand cmd2 = new MySqlCommand(sql2, conn);
                            cmd2.Parameters.AddWithValue("@userID2", userID);
                            MySqlDataReader rdr2 = cmd2.ExecuteReader();

                            rdr2.Read();

                            double sumOfTotalHours = (double)rdr2[0]; //second sql pull

                            rdr2.Close();
                            conn.Close();

                            double percentStep1 = sumOfTotalHoursBrewing / sumOfTotalHours; //first step is division to find the decimal amount
                            string percentStep2 = (percentStep1.ToString("P1", CultureInfo.InvariantCulture)); //converts that said decimal amount into a string percentage 

                            Console.Clear();
                            displayThis = ("[10] Total time spent brewing beer in 26 days: " + percentStep2); //adds a value to displayThis
                        }
                        break;
                    case "0":
                    case "main menu":
                    case "0 main menu": //main menu - home screen
                    case "[0]":
                    case "[0] main menu":
                        {
                            Console.Clear();
                            return;
                        }
                    default:
                        {
                            displayThis = ("Not a valid input - Please try again"); //adds a value to displayThis telling the user they entered something not offered
                        }
                        break;

                }
            } while (running);
        }
    }
}
