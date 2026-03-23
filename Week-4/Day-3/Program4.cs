using System;


namespace C__Programs
{
    class Program4
    {
        public static void Run()
        {

            Console.Write("Enter Number: ");
            int num = int.Parse(Console.ReadLine());
            int even = 0;
            int odd = 0;
            int sum = 0;
            int i = 0;
            while (i <= num)
            {
                if (i % 2 == 0)
                {
                    even++;
                }
                else
                {
                    odd++;
                }
                sum += i;
                i++;
            }
            Console.WriteLine($"Even Numbers: {even}");
            Console.WriteLine($"Odd Numbers: {odd}");
            Console.WriteLine($"Sum of Numbers: {sum}");

        }
    }
}
