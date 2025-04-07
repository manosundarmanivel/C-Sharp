using System;
using System.Collections.Generic;
using System.Linq; 

namespace Task4
{
    public class Student
    {
        public string name { get; set; }
        public double grade { get; set; }
        public int age { get; set; }

        public Student(string name, double grade, int age)
        {
            this.name = name;
            this.grade = grade;
            this.age = age;
        }

        public override string ToString()
        {
            return $"Name: {name}, Grade: {grade}, Age: {age}";
        }
    }

    class Program
    {
        static void Main(string[] args) 
        {
            List<Student> students = new List<Student>
            {
                new Student("Manoj", 8.5, 20),
                new Student("Ravi", 9.0, 22),
                new Student("Ajay", 7.5, 21),
                new Student("Suresh", 8.0, 23),
                new Student("Ramesh", 9.5, 24),
                new Student("Rajesh", 8.2, 25),
                new Student("Kumar", 7.8, 26)
            };

            Console.Write("Enter the threshold grade: ");
            if (!double.TryParse(Console.ReadLine(), out double threshold))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                threshold = 8.0; 
            }

            var filteredStudents = students
                .Where(s => s.grade > threshold)
                .OrderByDescending(s => s.grade)
                .ThenBy(s => s.age)
                .ToList();

            if (filteredStudents.Count > 0)
            {
                Console.WriteLine("\nStudents with grade above threshold:");
                foreach (var student in filteredStudents)
                {
                    Console.WriteLine(student);
                }
            }
            else
            {
                Console.WriteLine("No students found with grade above the threshold.");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
