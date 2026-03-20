using System;
using System.Collections.Generic;

public record Student(int RollNumber, string Name, string Course, int Marks);

class Program
{
    static List<Student> students = new List<Student>();

    static void Main()
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== Student Record Management =====");
            Console.WriteLine("1. Add Students");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search by Roll Number");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input! Enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddStudents();
                    break;
                case 2:
                    DisplayStudents();
                    break;
                case 3:
                    SearchStudent();
                    break;
                case 4:
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }

        } while (choice != 4);
    }

    // 🔹 Add Students
    static void AddStudents()
    {
        Console.Write("Enter number of students: ");
        if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
        {
            Console.WriteLine("Invalid number!");
            return;
        }

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nEnter details for Student {i + 1}:");

            int roll = ReadValidInt("Enter Roll Number: ");
            string name = ReadNonEmpty("Enter Name: ");
            string course = ReadNonEmpty("Enter Course: ");
            int marks = ReadValidMarks("Enter Marks (0-100): ");

            students.Add(new Student(roll, name, course, marks));
        }
    }

    // 🔹 Display Students
    static void DisplayStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No records found.");
            return;
        }

        Console.WriteLine("\nStudent Records:");
        foreach (var s in students)
        {
            Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
        }
    }

    // 🔹 Search Student
    static void SearchStudent()
    {
        int roll = ReadValidInt("Enter Roll Number to search: ");

        var student = students.Find(s => s.RollNumber == roll);

        Console.WriteLine("\nSearch Result:");
        if (student != null)
        {
            Console.WriteLine("Student Found:");
            Console.WriteLine($"Roll No: {student.RollNumber} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    // 🔹 Input Validation Methods
    static int ReadValidInt(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out value) && value > 0)
                return value;

            Console.WriteLine("Invalid input! Enter a positive number.");
        }
    }

    static int ReadValidMarks(string message)
    {
        int marks;
        while (true)
        {
            Console.Write(message);
            if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0 && marks <= 100)
                return marks;

            Console.WriteLine("Marks must be between 0 and 100.");
        }
    }

    static string ReadNonEmpty(string message)
    {
        string input;
        while (true)
        {
            Console.Write(message);
            input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
                return input;

            Console.WriteLine("Input cannot be empty.");
        }
    }
}