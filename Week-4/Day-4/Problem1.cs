using System;

namespace C__Programs
{
    internal class Calculator
    {
        public static int Addition(int a, int b)
        {
            return a + b;
        }

        public static int Subtraction(int a, int b)
        {
            return a - b;
        }

        public static int Multiplication(int a, int b)
        {
            return a * b;
        }

        public static int Division(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("Division by zero is not allowed");
                return 0;
            }
            return a / b;
        }

        static void Main(string[] args)
        {
            Console.Write("Enter Number 1: ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Enter Number 2: ");
            int y = int.Parse(Console.ReadLine());

            Console.WriteLine("Choose Operation:");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");

            int choice = int.Parse(Console.ReadLine());

            int result = 0;

            switch (choice)
            {
                case 1:
                    result = Addition(x, y);
                    break;

                case 2:
                    result = Subtraction(x, y);
                    break;

                case 3:
                    result = Multiplication(x, y);
                    break;

                case 4:
                    result = Division(x, y);
                    break;

                default:
                    Console.WriteLine("Invalid Operation");
                    return;
            }

            Console.WriteLine("Result = " + result);
        }
    }
}