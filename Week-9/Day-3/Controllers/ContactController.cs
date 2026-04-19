using Microsoft.AspNetCore.Mvc;
using ContactService.Services;
using ContactService.Models;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _service;

        public ContactsController(IContactService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var contact = await _service.GetById(id);
            return contact == null ? NotFound() : Ok(contact);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Contact contact)
        {
            var result = await _service.Add(contact);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Contact contact)
        {
            if (id != contact.ContactId) return BadRequest();
            await _service.Update(contact);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return NoContent();
        }
    }
}