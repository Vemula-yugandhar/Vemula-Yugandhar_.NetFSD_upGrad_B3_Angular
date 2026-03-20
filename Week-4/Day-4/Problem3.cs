using System.ComponentModel.Design;

namespace C_Sharp_Programs
{
    class Product
    {
        private int _productId;
        private string _productName;
        private double _unitPrice;
        private int _qty;

        // Constructor with productId parameter
        public Product(int productId)
        {
            this._productId = productId;
        }

        // Readonly property
        public int ProductId
        {
            get { return _productId; }
        }

        // Property for ProductName
        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        // Property for UnitPrice
        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        // Property for Quantity
        public int Quantity
        {
            get { return _qty; }
            set { _qty = value; }
        }

        // Method to display details
        public void ShowDetails()
        {
            double total = _unitPrice * _qty;

            Console.WriteLine("Product ID: " + ProductId);
            Console.WriteLine("Product Name: " + ProductName);
            Console.WriteLine("Unit Price: " + UnitPrice);
            Console.WriteLine("Quantity: " + Quantity);
            Console.WriteLine("Total Amount: " + total);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter Product ID: ");
            int id = int.Parse(Console.ReadLine());

            Product p = new Product(id);

            Console.Write("Enter Product Name: ");
            p.ProductName = Console.ReadLine();

            Console.Write("Enter Unit Price: ");
            p.UnitPrice = double.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            p.Quantity = int.Parse(Console.ReadLine());

            Console.WriteLine("\nProduct Details");
            p.ShowDetails();

        }
    }
}

