using System;

namespace C__Programs
{
    class Program1
    {
        public static void Run()
        {

            string name = "";
            int marks;

            Console.WriteLine("Enter Name:");
            name = Console.ReadLine();

            Console.WriteLine("Enter Marks:");
            if (!(int.TryParse(Console.ReadLine(), out marks)))
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            if (marks >= 90)
            {
                Console.WriteLine($"{name}");
                Console.WriteLine("Grade: A");
            }
            else if (marks >= 75)
            {
                Console.WriteLine($"{name}");
                Console.WriteLine("Grade: B");
            }
            else if (marks >= 60)
            {
                Console.WriteLine($"{name}");
                Console.WriteLine("Grade: C");
            }
            else if (marks >= 35)
            {
                Console.WriteLine($"{name}");
                Console.WriteLine("Grade: D");
            }
            else
            {
                Console.WriteLine($"{name}");
                Console.WriteLine("Grade: Fail");
            }

        }
    }
}
