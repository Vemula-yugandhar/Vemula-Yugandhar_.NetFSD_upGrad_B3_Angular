/*Problem 3 (Level-2): Product Entry with List Display
Scenario:
An admin wants to add multiple products and view them in a list on the same page.
Requirements:
1.  Create a form to input: 
•	Product Name 
•	Price 
•	Quantity 
2.  On submission: 
•	Add product to a List 
•	Display all products in tabular format 
3. Use ViewBag to store and display list
Technical Constraints
1.  Use Attribute-based routing 
2.  Use HttpPost for adding data 
3.  Maintain list temporarily (no database) 
4.  Use static list or TempData alternative NOT allowed
Expectations
1.  Data persists across multiple submissions (within session scope) 
2.  Table updates dynamically after each submission 
3.  Clean UI separation (form + table)
Learning Outcome
1.  Managing collections using ViewBag/ViewData 
2. Handling repeated form submissions 
3. Understanding limitations of ViewBag
*/


using ASP_.NET_Basics_Day_0.Models;
using Microsoft.AspNetCore.Mvc;


namespace ASP_.NET_Basics_Day_0.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> productObj = new List<Product>()
        {
            new Product {ProductName="Laptop", Price = 50000, Quantity=5},
            new Product {ProductName="Mobile", Price = 25000, Quantity=10}

        };
        public IActionResult ShowProducts()
        {
            return View(productObj);
        }

        [HttpGet]
        public IActionResult AddProducts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProducts(Product products)
        {
            productObj.Add(products);
            return RedirectToAction("ShowProducts");
        }
    }
}
