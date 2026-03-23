using System;

public class Class1
{
	public Class1()
	{
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());

        Console.Write("Enter Experience: ");
        int exp = int.Parse(Console.ReadLine());

        if (exp < 2)
        {
            salary = salary * 1.05;
        }
        else if (exp >= 2 && exp <= 5)
        {
            salary = salary * 1.10;
        }
        else
        {
            salary = salary * 1.15;
        }

        Console.WriteLine($"Salary After Bonus: {salary}");
    }
}
