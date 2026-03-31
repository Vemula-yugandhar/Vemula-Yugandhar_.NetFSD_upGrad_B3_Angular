using ASP.NET_Day_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Day_3.Controllers

{


    public class ContactController : Controller
    {
        static List<ContactInfo> contactList = new List<ContactInfo>() {
        new ContactInfo {ContactId=01, FirstName="Vemula", LastName="Yugandhar", CompanyName="Cognizant", EmailId="yugandharvemula44@gmail.com", PhoneNumber=6303492875, Designation="Developer" },
        new ContactInfo {ContactId=02, FirstName="Manoj", LastName="Kumar", CompanyName="Delloite", EmailId="Manoj@gmail.com", PhoneNumber=9794773694, Designation="Associate Developer" },
        new ContactInfo {ContactId=03, FirstName="Amit", LastName="shah", CompanyName="TCS", EmailId="Amit@gmail.com", PhoneNumber=8634773694, Designation="Tester" }

        };

        //Showw All Contacts
        public IActionResult Contacts()
        {
            return View(contactList);
        }


        //Get contact details by ID
        [HttpGet]
        public IActionResult GetContactByID()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details(int ContactId)
        {
            var result = contactList.FirstOrDefault(i => i.ContactId == ContactId);
            return View(result);
        }


        //Add new contact
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {
                contactList.Add(contactInfo);
                return RedirectToAction("Contacts");
            }
            return View(contactInfo);
        }
    }
}
