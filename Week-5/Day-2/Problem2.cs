using System.Dynamic;
using System.Linq.Expressions;

namespace Oops_Concepts
{

    using System;

    class Calculator
    {
        public void Divide(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                Console.WriteLine("Result: " + result);
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Calculator calc = new Calculator();

            while (true)
            {
                Console.WriteLine("\n===== Safe Division Calculator =====");

                
                Console.WriteLine("Enter Numerator: ");
                int numerator = int.Parse(Console.ReadLine());
                int denominator = int.Parse(Console.ReadLine());

                calc.Divide(numerator, denominator);

                Console.Write("\nDo you want to continue? (y/n): ");
                string choice = Console.ReadLine().ToLower();

                if (choice != "y")
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }
            }

            Console.WriteLine("Program ended successfully.");
        }

       
    }
}
