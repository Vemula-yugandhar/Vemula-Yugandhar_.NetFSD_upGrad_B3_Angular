using Oops_Concepts;

namespace Oops_Concepts
{
    public class Product {
       public string Name { get; set; }
       public int Price { get; set; }

        public Product(string name, int price) {
            Name = name;
            Price = price;
        }

        public virtual  decimal CalculateDiscount(int discount)
        {
            return discount;
        }

    }

}

public class Electronics : Product
{
    public Electronics(string name, int price) : base(name, price)
    {
    }

    public override decimal CalculateDiscount(int discount)
    {
        return Price - (Price * discount / 100m); // 5% discount
    }
}


public class Clothing : Product {
    public Clothing(string name, int price) : base(name, price)
    { }

    public override decimal CalculateDiscount(int discount)
    {
        return Price - (Price * discount / 100m); // 15% discount
    }
}



internal class Program
    {
        static void Main(string[] args)
        {

        Electronics electronics = new Electronics("laptop", 5000);
        Clothing clothing = new Clothing("Shirt", 1000);

        Console.WriteLine("Final amount after discount: " + electronics.CalculateDiscount(5));
        Console.WriteLine("Final amount after discount: " + clothing.CalculateDiscount(15));



    }
    }

