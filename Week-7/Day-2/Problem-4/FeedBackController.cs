/*Problem 4 (Level-2): Feedback Form with Conditional Message
Scenario:
A website collects user feedback and displays different messages based on rating.
Requirements:
1.  Create a feedback form: 
•	Name 
•	Comments 
•	Rating (1–5) 
2.  Submit using HttpPost 
3.  After submission: 
•	Show “Thank You” message if rating ≥ 4 
•	Show “We will improve” message if rating < 4 
4.  Use ViewData to pass message
Technical Constraints
1.  Use Attribute routing 
2.  Do NOT use TempData/Session 
3. Do NOT use database 
4. Must use ViewData for message handling
Expectations
1.  Correct conditional logic 
2.  Proper use of ViewData 
3.  Clean routing structure
Learning Outcome
1. Conditional rendering using server-side logic 
2. Using ViewData for dynamic UI behavior 
3.  Reinforcing form handling concepts
*/


using Microsoft.AspNetCore.Mvc;

namespace ASP_.NET_Basics_Day_0.Controllers
{
    public class FeedBackController : Controller
    {
        [HttpGet]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Form(string name, string comments, int rating)
        {
            ViewData["Name"] = name;
            ViewData["Comments"] = comments;
            ViewData["Rating"] = rating;

            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You for your positive feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }

            return View();
        }
    }
}
