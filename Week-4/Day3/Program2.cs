using System;

namespace C__Programs
{
    internal class program2
    {
       public static void Run()
        {
            Console.Write("Enter Number 1 : ");
            int x = int.Parse(Console.ReadLine());

            Console.Write("Enter Number 2 : ");
            int y = int.Parse(Console.ReadLine());

            Console.Write("Enter Operator 1 : ");
            char op = char.Parse(Console.ReadLine());
            int z = 0;

            switch (op) {
                case '+':
                    z = x + y;
                    break;
                case '-':
                    z = x - y;
                    break;
                case '*':
                    z = x * y;
                    break;
                case '/':
                    if(y == 0)
                    {
                        Console.WriteLine("Y should be Grater than 0");
                     return;
                    }
                    z = x / y;
                    break;
                default:
                    Console.WriteLine("Invalid Operator");
                    break;

            }

            Console.WriteLine($"Result: {z}");
        }
    }
}
