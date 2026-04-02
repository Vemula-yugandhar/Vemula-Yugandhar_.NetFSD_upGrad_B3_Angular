using ContactManagementApp.Models;
using ContactManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagementApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        // Constructor Injection
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // Display all contacts
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // GET: Search by Id page
        [HttpGet]
        public IActionResult GetContactById()
        {
            return View();
        }

        // POST: Search contact by Id
        [HttpPost]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);
            return View(contact);
        }

        // GET: Add Contact
        [HttpGet]
        public IActionResult AddContact()
        {
            return View();
        }

        // POST: Add Contact
        [HttpPost]
        public IActionResult AddContact(ContactInfo contactInfo)
        {
            _contactService.AddContact(contactInfo);
            return RedirectToAction("ShowContacts");
        }
    }
}