using System.Collections;
using System.ComponentModel;
using System.Dynamic;
using System.Net.WebSockets;

namespace Collections
{
    
    internal class Problem1
    {

        //Method to get list
        static void GetList(List<Product> products,List<Product> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine($"{item.ProCode}\t{item.ProName}\t{item.ProMrp}");
            }
            Console.WriteLine("===========================================================");
        }
        static void Main()
        {
            Product product = new Product();
            var products = product.GetProducts();


            // LINQ QUERIES


            //Query 1
            //Write a LINQ query to search and display all products with category “FMCG”.
            Console.WriteLine("Query 1");
            var result = (from p in products
              where p.ProCategory == "FMCG"
              select p).ToList();


            //Query 2
            //Write a LINQ query to search and display all products with category “Grain”.
            Console.WriteLine("Query 2");
            result = (from p in products
              where p.ProCategory == "Grain"
              select p).ToList();

            GetList(products, result);

            //Query 3
            //Write a LINQ query to sort products in ascending order by product code.
            Console.WriteLine("Query 3");
            var result = (from p in products
              orderby p.ProCode ascending
              select p).ToList();

           GetList(products, result);

 
            //Query 4
            //Write a LINQ query to sort products in ascending order by product Category.
            Console.WriteLine("Query 4");
            result = (from p in products
              orderby p.ProCategory ascending
              select p).ToList();

            GetList(products, result);

            
            //Query 5
            //Write a LINQ query to sort products in ascending order by product Mrp.
            result = (from p in products
              orderby p.ProMrp ascending
              select p).ToList();

            GetList(products, result);

            //Query 6
            //Write a LINQ query to sort products in descending order by product Mrp.
            Console.WriteLine("Query 6");
            result = (from p in products
              orderby p.ProMrp descending
              select p).ToList();

            GetList(products, result);

            //Query 7
            //Write a LINQ query to display products group by product Category.
            Console.WriteLine("Query 7");
            result = products.GroupBy(p => p.ProCategory);
            GetList(products, result);


            //Query8
            //Write a LINQ query to display products group by product Mrp.
            Console.WriteLine("Query 8");

                result = (from p in products
                            group p by p.ProMrp into g
                            select g).ToList();

                // Display
                foreach (var group in result)
                {
                    Console.WriteLine($"MRP: {group.Key}");
                    foreach (var item in group)
                    {
                        Console.WriteLine($"   {item.ProName} - {item.ProCategory}");
                    }
                }

            //Query 9
            //Write a LINQ query to display product detail with highest price in FMCG category.
            result = products
                           .Where(p => p.ProCategory == "FMCG")
                           .OrderByDescending(p => p.ProMrp)
                           .FirstOrDefault();

            if (result != null)
            {
                Console.WriteLine("Highest Price Product in FMCG:");
                Console.WriteLine($"{result.ProCode}\t{result.ProName}\t{result.ProMrp}");
            }
            else
            {
                Console.WriteLine("No FMCG products found");
            }


            //Query 10
            //Write a LINQ query to display count of total products.
            int count = products.Count();
            Console.WriteLine("Total Products: " + count);


            //Query 11
            //Write a LINQ query to display count of total products with category FMCG.
            result = products
                    .Where(p => p.ProCategory == "FMCG")
                    .ToList();

            count = result.Count;
            Console.WriteLine("Total Products in FMCG: " + count);

            //Query 12
            //Write a LINQ query to display Max price
            double maxPrice = products.Max(p => p.ProMrp);

            Console.WriteLine("Maximum Price: " + maxPrice);


            //Query 13
            //Write a LINQ query to display Min price
            double minPrice = products.Min(p => p.ProMrp);

            Console.WriteLine("Maximum Price: " + minPrice);

            //Query 14
            //Write a LINQ query to display whether all products are below Mrp Rs.30 or not.
            Console.WriteLine("Query 14");
            result = (from p in products
                        where p.ProMrp >= 30
                        select p).Any();

            Console.WriteLine(!result);


        }
    }
}
