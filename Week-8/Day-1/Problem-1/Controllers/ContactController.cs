using Dapper_Service_and_Repository_ContactIInformation.Models;
using Dapper_Service_and_Repository_ContactIInformation.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Dapper_Service_and_Repository_ContactIInformation.Controllers
{
   
        public class ContactController : Controller
        {
            private readonly IContactRepository _repo;

            public ContactController(IContactRepository repo)
            {
                _repo = repo;
            }

            [HttpGet("ShowContacts")]
            public IActionResult ShowContacts()
            {
                var contacts = _repo.GetAllContacts();
            LoadDropdowns();
            return View(contacts);
            }

            [HttpGet("GetContactById/{id}")]
            public IActionResult GetContactById(int id)
            {
                var contact = _repo.GetContactById(id);
                if (contact == null)
                   return NotFound();

                return View(contact);
            }

            [HttpGet("AddContact")]
            public IActionResult AddContact()
            {
            LoadDropdowns();
            return View();
            }

            [HttpPost("AddContact")]
            public IActionResult AddContact(ContactInfo contact)
            {
                if (ModelState.IsValid)
                {
                  _repo.AddContact(contact);
                   return RedirectToAction("ShowContacts");
                }

            LoadDropdowns();
            return View(contact);
            }

            [HttpGet("EditContact/{id}")]
            public IActionResult EditContact(int id)
            {
                var contact = _repo.GetContactById(id);
                if (contact == null)
                    return NotFound();

            LoadDropdowns();
            return View(contact);
            }

            [HttpPost("EditContact")]
            [ValidateAntiForgeryToken]
            public IActionResult EditContact(ContactInfo contact)
            {
                if (ModelState.IsValid)
                {
                    _repo.UpdateContact(contact);
                
                   return RedirectToAction("ShowContacts");
                }

            LoadDropdowns();
            return View(contact);
            }

            [HttpGet("DeleteContact/{id}")]
            public IActionResult DeleteContact(int id)
            {
                var contact = _repo.GetContactById(id);
                if (contact == null)
                    return NotFound();

                return View(contact);
            }

            [HttpPost("DeleteContact/{id}")]
            [ValidateAntiForgeryToken]
            public IActionResult DeleteConfirmed(int id)
            {
                _repo.DeleteContact(id);
                return RedirectToAction("ShowContacts");
            }

        private void LoadDropdowns()
        {
            ViewBag.Companies = new SelectList(_repo.GetCompanies(), "CompanyId", "CompanyName");
            ViewBag.Departments = new SelectList(_repo.GetDepartments(), "DepartmentId", "DepartmentName");
        }

    }
    
}
