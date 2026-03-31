/*Problem 1 (Level-1): Simple Calculator
Scenario:
Build a simple calculator web page that performs addition of two numbers.
Requirements:
1. Accept two numbers using a form 
2. Submit using HttpPost 
3. Display result on the same or another page 
3. Pass result using ViewData
Technical Constraints
1. Use Attribute routing 
2.  No JavaScript (pure server-side processing) 
3.  No Model binding (use form collection or parameters)
Expectations
1. Correct calculation logic 
2.  Proper HttpPost handling 
3.  Result displayed using ViewData
Learning Outcome
1.  Handling user input via forms 
2. Passing computed values using ViewData 
3. Understanding request lifecycle
*/





using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ASP_.NET_Basics_Day_0.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(int n1, int n2, String operation)
        {
            double result = 0;
            switch (operation) {
                case "Add":
                    result = n1 + n2;
                    
                    break;
                case "Sub":
                    result = n1 - n2;
                    break;

                case "Mul":
                    result = n1 * n2;
                    break;

                default:

                    if (n2 != 0)
                        result = (double)n1 / n2;
                    else
                        ViewBag.Result = "Cannot divide by zero";
                    break;
            }
            if (operation != "Div" || n2 != 0)
            {
                ViewBag.Result = result;
            }

            return View();
        }
    }
}
