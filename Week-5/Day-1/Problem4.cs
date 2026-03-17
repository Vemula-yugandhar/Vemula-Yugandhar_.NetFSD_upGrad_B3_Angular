using Oops_Concepts;
namespace Oops_Concepts { 
    class Vehicle { 
        public decimal RentalRatePerDay { get; set; }
        public string Brand { get; set; }
        public Vehicle(string brand, decimal rentalRatePerDay) 
        { 
            Brand = brand; RentalRatePerDay = rentalRatePerDay; 
        } 
        public virtual decimal CalculateRental(int days) 
        { 
            if (days <= 0) throw new ArgumentException("Rental days must be greater than 0"); 
            return RentalRatePerDay * days; 
        } 
    } 
}
class Car : Vehicle 
{ 
    public Car(string brand, decimal rentalRatePerDay) : base(brand, rentalRatePerDay) 
    { } 
    public override decimal CalculateRental(int days) 
    { 
        decimal total = base.CalculateRental(days); 
        return total + 500; 
    } 
}
class Bike : Vehicle 
{ 
    public Bike(string brand, decimal rentalRatePerDay) : base(brand, rentalRatePerDay) 
    { } 
    public override decimal CalculateRental(int days) 
    { 
        decimal total = base.CalculateRental(days); 
        return total - (total * 0.05m); 
    } 
}
internal class Program { 
    static void Main(string[] args) 
    { 
        Vehicle car = new Car("Toyota", 2000);
        Vehicle bike = new Bike("Yamaha", 800); 
        Console.WriteLine("Car Rental = " + car.CalculateRental(3)); 
        Console.WriteLine("Bike Rental = " + bike.CalculateRental(3)); 
    } 
}