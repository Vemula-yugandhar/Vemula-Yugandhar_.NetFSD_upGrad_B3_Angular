using System;

class Program
{
    static (double sales, int rating) GetPerformance(double sales, int rating)
    {
        return (sales, rating);
    }

    static void Main()
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Sales Amount: ");
        double sales = double.Parse(Console.ReadLine());

        Console.Write("Enter Rating (1-5): ");
        int rating = int.Parse(Console.ReadLine());

        var result = GetPerformance(sales, rating);

        string performance = result switch
        {
            (>= 100000, >= 4) => "High Performer",
            (>= 50000, >= 3) => "Average Performer",
            _ => "Needs Improvement"
        };

        Console.WriteLine($"\nEmployee Name: {name}");
        Console.WriteLine($"Sales Amount: {result.sales}");
        Console.WriteLine($"Rating: {result.rating}");
        Console.WriteLine($"Performance: {performance}");
    }
}