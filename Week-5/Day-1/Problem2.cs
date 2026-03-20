using Oops_Concepts;

namespace Oops_Concepts
{


    public class Employee
    {
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }

        public Employee(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }

        public virtual decimal CalculateSalary()
        {
            return BaseSalary;
        }
    }
}
class Manager : Employee
{
    public Manager(string name, decimal baseSalary) : base(name, baseSalary)
    {
    }

    public override decimal CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.20m);
    }
}
class Developer : Employee
{
    public Developer(string name, decimal baseSalary) : base(name, baseSalary)
    {
    }

    public override decimal CalculateSalary()
    {
        return BaseSalary + (BaseSalary * 0.10m);
    }
}
internal class Program
    {
        static void Main(string[] args)
        {
        Employee manager = new Manager("Rahul", 50000);
        Employee developer = new Developer("Amit", 50000);

        Console.WriteLine($"Manager Salary = {manager.CalculateSalary()}");
        Console.WriteLine($"Developer Salary = {developer.CalculateSalary()}");
    }
    }

