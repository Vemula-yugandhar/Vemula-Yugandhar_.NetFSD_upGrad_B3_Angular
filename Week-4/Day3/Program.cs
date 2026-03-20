using System;


namespace C__Programs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Select Program");
            Console.WriteLine("1. Student Grade");
            Console.WriteLine("2. Calculator");
            Console.WriteLine("3. Employee Salary");
            Console.WriteLine("4. Number Anlysis");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Program1.Run();
                    break;
                case 2:
                    Program2.Run();
                    break;
                case 3:
                    Program3.Run();
                    break;
                case 4:
                    Program4.Run();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }
}
