[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ContactsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ContactsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_context.Contacts.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var contact = _context.Contacts.Find(id);
        if (contact == null) return NotFound();
        return Ok(contact);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(Contact contact)
    {
        _context.Contacts.Add(contact);
        _context.SaveChanges();
        return Ok(contact);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update(int id, Contact contact)
    {
        if (id != contact.ContactId) return BadRequest();

        _context.Contacts.Update(contact);
        _context.SaveChanges();
        return Ok(contact);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete(int id)
    {
        var contact = _context.Contacts.Find(id);
        if (contact == null) return NotFound();

        _context.Contacts.Remove(contact);
        _context.SaveChanges();
        return Ok();
    }
}