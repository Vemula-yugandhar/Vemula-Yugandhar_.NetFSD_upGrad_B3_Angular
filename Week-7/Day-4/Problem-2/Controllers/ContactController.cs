using DataAccessLayer.Models;
using DataAccessLayer.Services;
using Entity_FrameWork_Contact_Management_Repository_service_pattern.Models;
using Entity_FrameWork_Contact_Management_Repository_service_pattern.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppUILayer.Controllers
{
    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // =========================
        // SHOW ALL CONTACTS
        // =========================
        [HttpGet("showcontacts")]
        public IActionResult ShowContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return View(contacts);
        }

        // =========================
        // GET CONTACT BY ID
        // =========================
        [HttpGet("details/{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = _contactService.GetContactById(id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        // =========================
        // ADD CONTACT - GET
        // =========================
        [HttpGet("add")]
        public IActionResult AddContact()
        {
            LoadDropdowns();
            return View();
        }

        // =========================
        // ADD CONTACT - POST
        // =========================
        [HttpPost("add")]
        public IActionResult AddContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.AddContact(contact);
                return RedirectToAction("ShowContacts");
            }

            LoadDropdowns();
            return View(contact);
        }

        // =========================
        // EDIT CONTACT - GET
        // =========================
        [HttpGet("edit/{id}")]
        public IActionResult EditContact(int id)
        {
            var contact = _contactService.GetContactById(id);

            if (contact == null)
                return NotFound();

            LoadDropdowns();
            return View(contact);
        }

        // =========================
        // EDIT CONTACT - POST
        // =========================
        [HttpPost("edit")]
        public IActionResult EditContact(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _contactService.UpdateContact(contact);
                return RedirectToAction("ShowContacts");
            }

            LoadDropdowns();
            return View(contact);
        }

        
        [HttpGet("delete/{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.GetContactById(id);

            if (contact == null)
                return NotFound();

            return View(contact);
        }

        // =========================
        // DELETE CONTACT - POST
        // =========================
        [HttpPost("delete/{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            _contactService.DeleteContact(id);
            return RedirectToAction("ShowContacts");
        }

        // =========================
        // LOAD DROPDOWNS
        // =========================
        private void LoadDropdowns()
        {
            ViewBag.Companies = new SelectList(
                _contactService.GetAllCompanies(),
                "CompanyId",
                "CompanyName"
            );

            ViewBag.Departments = new SelectList(
                _contactService.GetAllDepartments(),
                "DepartmentId",
                "DepartmentName"
            );
        }
    }
}