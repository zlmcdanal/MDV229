using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodingExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
           

            

            Dictionary<string, Student> students = new Dictionary<string, Student>(); //student dictionary

            Student currentStudent = null; //sets currentStudent to null

            bool running = true; //bool to close program if set to false

            do //loops menu so long as running = true
            {
                if (currentStudent == null)
                {
                    Console.WriteLine("There is currently no student selected"); //displays if no student is selected
                }
                else
                {
                    Console.WriteLine("Current student selected: " + currentStudent); //displays selected student
                }


                Console.Write("\nPlease choose from the following:\n" +
                    "1. Review & select a student\n" + //main menu
                    "2. Review GPA\n" +
                    "3. Edit Student\n" +
                    "4. Exit\n" +
                    "Choice: ");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "1":
                    case "review & select a student":
                    case "review and select a student": //choice to select a student
                    case "review/select a student":
                        {
                            currentStudent = selectStudent(students); //sets currentStudent to the selectStudent function
                        }
                        break;
                    case "2":
                    case "review gpa": //choice to review gpa
                        {
                            if(currentStudent == null)
                            {
                                Console.Clear(); //clears the screen
                                Console.WriteLine("Please select a student first"); //asks user to select a student first
                            }
                            else
                            {
                                Console.Clear(); //clears screen

                                currentStudent.displayGPA(); //calls to Student class to displayGPA method
                            }
                        }
                        break;
                    case "3":
                    case "edit student": //choice to edit student
                        {
                            Console.Clear(); //clears screen

                            currentStudent.changeGrade(); //calls to Student class to changeGrade method
                        }
                        break;
                    case "4":
                    case "exit": //choice to exit program
                        {
                            running = false; //exits program
                        }
                        break;
                }
            } while (running);
        }

        static Student selectStudent(Dictionary<string, Student> students)
        {
            
            Student chosenStudent = null; // chosen student set to null

            Console.Clear(); //clearing the screen
            
            Console.Write("Please choose a student:\n"); //student menu
            Console.Write("1. Jake Hope\n" +
                "2. Matthew Pope\n" +
                "3. Frank Mope\n" +
                "4. Tyler Soap\n" +
                "5. Jasper Lope");

            Console.Write("\nPlease type the name of the student you wish to see: "); //promting the user
            string userChoice = Console.ReadLine().ToLower();

            if (userChoice == "jake hope") //if jake hope, then chosenStudent is defined 
            {

                string name = "Jake Hope";
                var classes = new Dictionary<string, decimal>
                {
                    { "History of Prada", 80.00m },
                    { "Discovery of Old Navy 101", 96.00m },
                    { "Anatomy of Levi", 97.00m }, //jake's classes and grades
                    { "Victoria Secret Class", 90.00m },
                    { "Nike Class 382", 88.00m }
                };
                chosenStudent = new Student(name, classes);
                students.Add(name, chosenStudent);

                chosenStudent = students[name];

                
            }
            else if (userChoice == "matthew pope") //if matthew pope, then chosenStudent is defined 
            {
                string name = "Matthew Pope";
                var classes = new Dictionary<string, decimal>()
                {
                    { "Introduction to Nike", 69.00m },
                    { "Vans Lecture 102", 53.00m }, //matthew's classes and grades
                    { "Fundamentals of Forever 21", 38.00m },
                    { "Intermediate American Eagle", 71.00m },
                    { "Principles of Adidas", 73.00m }
                };
                 
                chosenStudent = new Student(name, classes);
                students.Add(name, chosenStudent);

                chosenStudent = students[name];
            }
            else if (userChoice == "frank mope") //if frank mope, then chosenStudent is defined 
            {
                string name = "Frank Mope";
                var classes = new Dictionary<string, decimal>
                {
                    { "General Studies of Holister", 86.00m },
                    { "Discovery of Old Navy 101", 97.00m },
                    { "Vans Lecture 102", 79.00m }, //frank's classes and grades
                    { "Victoria Secret Class", 100.00m },
                    { "Intermediate American Eagle", 100.00m }
                };
                
                chosenStudent = new Student(name, classes);
                students.Add(name, chosenStudent);

                chosenStudent = students[name];
            }
            else if (userChoice == "tyler soap") //if tyler soap, then chosenStudent is defined 
            {
                string name = "Tyler Soap";
                var classes = new Dictionary<string, decimal>
                {
                    { "Intermediate American Eagle", 99.00m },
                    { "Discovery of Old Navy 101", 68.00m }, //tyler's classes and grades
                    { "Anatomy of Levi", 88.00m },
                    { "Victoria Secret Class", 76.00m },
                    { "Nike Class 382", 72.00m }
                };
                
                chosenStudent = new Student(name, classes);
                students.Add(name, chosenStudent);

                chosenStudent = students[name];
            }
            else if (userChoice == "jasper lope") //if jasper lope, then chosenStudent is defined 
            {
                string name = "Jasper Lope";
                var classes = new Dictionary<string, decimal>
                {
                    { "History of Prada", 95.00m },
                    { "Discovery of Old Navy 101", 95.00m },  //jasper's classes and grades
                    { "Intermediate American Eagle", 100.00m },
                    { "Victoria Secret Class", 100.00m },
                    { "Vans Lecture 102", 100.00m }
                };
                
                chosenStudent = new Student(name, classes);
                students.Add(name, chosenStudent);

                chosenStudent = students[name];
            }
            else
            {
                Console.WriteLine("Not a valid student name"); //user error message
            }

            Console.Clear();

            Console.WriteLine("Student: " + chosenStudent + "\n"); //displays user choice
            chosenStudent.display();

            Console.WriteLine("\nPress enter to return to the main menu..."); //message to return to the menu
            Console.ReadKey();

            Console.Clear();

            return chosenStudent; //returns chosenStudent
        }
    }
}
