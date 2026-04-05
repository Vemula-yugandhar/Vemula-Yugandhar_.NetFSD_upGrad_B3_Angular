using Entity_FrameWork_Contact_Management_Repository_service_pattern.Models;

namespace Entity_FrameWork_Contact_Management_Repository_service_pattern.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all contacts with Company & Department
        public List<ContactInfo> GetAllContacts()
        {
            return _context.Contacts
                           .Include(c => c.Company)
                           .Include(c => c.Department)
                           .ToList();
        }

        // Get one contact by id
        public ContactInfo? GetContactById(int id)
        {
            return _context.Contacts
                           .Include(c => c.Company)
                           .Include(c => c.Department)
                           .FirstOrDefault(c => c.ContactId == id);
        }

        // Add new contact
        public void AddContact(ContactInfo contact)
        {
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        // Update existing contact
        public void UpdateContact(ContactInfo contact)
        {
            _context.Contacts.Update(contact);
            _context.SaveChanges();
        }

        // Delete contact by id
        public void DeleteContact(int id)
        {
            var contact = _context.Contacts.Find(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
            }
        }

        // Get all companies
        public List<Company> GetAllCompanies()
        {
            return _context.Companies.ToList();
        }

        // Get all departments
        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }
    }
}
