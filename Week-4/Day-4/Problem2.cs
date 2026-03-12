using System;

namespace C_Sharp_Programs
{
    internal class Student
    {
        static double CalculateAverage(int m1, int m2, int m3)
        {
            double average = (m1 + m2 + m3) / 3.0;
            return average;
        }

        static void Grade(double result)
        {
            if (result >= 90)
            {
                Console.WriteLine("Result : Grade A");
            }
            else if (result >= 75)
            {
                Console.WriteLine("Result : Grade B");
            }
            else if (result >= 35)
            {
                Console.WriteLine("Result : Grade C");
            }
            else
            {
                Console.WriteLine("Result : Fail");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Subject 1 Marks:");
            int m1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Subject 2 Marks:");
            int m2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Subject 3 Marks:");
            int m3 = int.Parse(Console.ReadLine());

            double result = CalculateAverage(m1, m2, m3);

            Console.WriteLine("Average Marks: " + result);

            Grade(result);
        }
    }
}