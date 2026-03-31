/*Problem 1 (Level-1): Student Registration &Display
Scenario:
A small institute wants a simple web page where users can enter student details and see the submitted data on another page.
Requirements:
1.Create a form to accept: 
•	Student Name 
•	Age 
•	Course 
2. Submit the form using HttpPost 
3.Redirect to another action method to display entered data 
4.  Pass data using ViewBag OR ViewData

Technical Constraints
1.  Use Attribute-based routing 
2.  Do NOT use Model or Database 
3.  Use only ViewBag/ViewData for state management 
4.  Use separate actions for: 
•	GET → Display form 
•	POST → Handle submission
Expectations
1. Clean separation of GET and POST actions 
2. Correct usage of ViewBag/ViewData 
3. Proper routing using attributes 
4.Data displayed correctly after submission
Learning Outcome
1.  Understanding of HttpGet vs HttpPost 
2. Basics of state management using ViewBag/ ViewData
3.Hands - on with attribute routing*/

using Microsoft.AspNetCore.Mvc;

namespace ASP_.NET_Basics_Day_0.Controllers
{
    public class StudentController : Controller
    {
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Register(string name, int age, string course)
        {
            // Pass data using ViewBag and redirect
            TempData["Name"] = name;
            TempData["Age"] = age;
            TempData["Course"] = course;

            return RedirectToAction("Display");
        }

        
        [HttpGet("display")]
        public IActionResult Display()
        {
            ViewBag.Name = TempData["Name"];
            ViewBag.Age = TempData["Age"];
            ViewBag.Course = TempData["Course"];

            return View();
        }
    }
}
