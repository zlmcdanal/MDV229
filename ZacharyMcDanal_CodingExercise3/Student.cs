using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZacharyMcDanal_CodingExercise3
{
    class Student
    {
        private string _name;
        private Dictionary<string, decimal> _classes;

        public Student(string Name, Dictionary<string, decimal> Classes) //constructor for Student
        {
            _name = Name;
            _classes = Classes;
        }

        public override string ToString()
        {
            return _name;
        }

        public string getName()
        {
            return _name;
        }

        public void display() // displays classes, grades, and letter grades
        {
            string letterGrade;

            foreach (KeyValuePair<string, decimal> slot in _classes)
            {
                if (slot.Value > 89.4m)
                {
                    letterGrade = "A";
                    Console.WriteLine("Class: {0}   |    Grade: {1}   |    Letter-Grade: {2}", slot.Key, slot.Value, letterGrade);
                } //if grade is A display this
                else if (slot.Value < 89.5m && slot.Value > 79.4m)
                {
                    letterGrade = "B";
                    Console.WriteLine("Class: {0}   |    Grade: {1}   |    Letter-Grade: {2}", slot.Key, slot.Value, letterGrade);
                }//if grade is B display this
                else if (slot.Value < 79.5m && slot.Value > 72.4m)
                {
                    letterGrade = "C";
                    Console.WriteLine("Class: {0}   |    Grade: {1}   |    Letter-Grade: {2}", slot.Key, slot.Value, letterGrade);
                }//if grade is C display this
                else if (slot.Value < 72.5m && slot.Value > 69.4m)
                {
                    letterGrade = "D";
                    Console.WriteLine("Class: {0}   |    Grade: {1}   |    Letter-Grade: {2}", slot.Key, slot.Value, letterGrade);
                }//if grade is D display this
                else if (slot.Value < 69.5m)
                {
                    letterGrade = "F";
                    Console.WriteLine("Class: {0}   |    Grade: {1}   |    Letter-Grade: {2}", slot.Key, slot.Value, letterGrade);
                }//if grade is F display this
                
            }
        }

        public void displayGPA() //method to display GPA
        {


            decimal totalGrades = 0.0m;
            decimal credit;

            foreach (KeyValuePair<string, decimal> slot in _classes)
            {
                if (slot.Value > 89.4m)
                {
                    credit = 5.0m;
                    decimal GPA = (credit * 20) / 100;
                    totalGrades += GPA;
                }//if grade is A do this
                else if (slot.Value < 89.5m && slot.Value > 79.4m)
                {
                    credit = 4.0m;
                    decimal GPA = (credit * 20) / 100;
                    totalGrades += GPA;
                }//if grade is B do this
                else if (slot.Value < 79.5m && slot.Value > 72.4m)
                {
                    credit = 3.0m;
                    decimal GPA = (credit * 20) / 100;
                    totalGrades += GPA;
                }//if grade is C do this
                else if (slot.Value < 72.5m && slot.Value > 69.4m)
                {
                    credit = 2.0m;
                    decimal GPA = (credit * 20) / 100;
                    totalGrades += GPA;
                }//if grade is D do this
                else if (slot.Value < 69.5m)
                {
                    credit = 0.0m;
                    decimal GPA = (credit * 20) / 100;
                    totalGrades += GPA;
                }//if grade is F do this

            }
            Console.WriteLine("Current GPA: {0}", totalGrades); //final display of GPA
        }

        public void displayGradesToChange() //displays to the user the classes and grades which user will pick from to change grade
        {
            foreach (KeyValuePair<string, decimal> slot in _classes)
            {
                Console.WriteLine(slot.Key + " " + slot.Value);
            }

            Console.WriteLine("\nExit");
        }

        public void changeGrade() //allows user to change grade of selection
        {
            Console.WriteLine("Which classes grade would you like to change?\n");

            displayGradesToChange();

            string tempGradeChoiceToChange = Console.ReadLine();

            if(_classes.ContainsKey(tempGradeChoiceToChange))
            {
                Console.WriteLine("What will be the new grade for {0}?", tempGradeChoiceToChange);

                decimal newGradeInput;

                decimal.TryParse(Console.ReadLine(), out newGradeInput);

                if(newGradeInput < 101 && newGradeInput > 0)
                {
                    _classes[tempGradeChoiceToChange] = newGradeInput;
                }
                else
                {
                    Console.WriteLine("Not a valid grade input");
                }
                
            }
            else if (tempGradeChoiceToChange == "exit" || tempGradeChoiceToChange == "Exit")
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Not a valid class. Please type out the name of the class...");
            }
            
        }


     }
}
