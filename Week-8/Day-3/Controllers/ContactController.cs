using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_API_Day_1.Models;
using Web_API_Day_1.Repositories;

namespace Web_API_Day_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contact = _contactRepository.GetAllContacts();
            return Ok(contact);
        }

        [HttpGet("{id}")]
        public IActionResult GetContyactById(int id)
        {
            var contact = _contactRepository.GetContactById(id);
            if (contact == null)
            {
                return NotFound("Contact Doesn't exist");
            }
            else {
                return Ok(contact);
            }
            
        }

        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            var contacts = _contactRepository.AddContact(contact);
            return Ok("Contact Added successfully");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactInfo contact)
        {
            var UpdatedContact = _contactRepository.UpdateContact(id, contact);
            if (UpdatedContact == false)
            {
                return NotFound("Contact Doesn't exist");
            }
            else
            {
                return Ok("Contact Updated Successfully");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id) 
        {
            var contact = _contactRepository.DeleteContact(id);
            if (contact == false)
            {
                return NotFound("Contact Doesn't exist");
            }
            else
            {
                return Ok("ContactDeleted Successfully");
            }
        }

    }
}
