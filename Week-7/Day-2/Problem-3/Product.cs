using System.ComponentModel.DataAnnotations;

namespace ASP_.NET_Basics_Day_0.Models
{
    public class Product
    {
        public string ProductName { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}
