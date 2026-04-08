using Web_API_Day_1.Models;

namespace Web_API_Day_1.Repositories
{
    public class ContactRepository : IContactRepository
    {

        public static List<ContactInfo> contacts = new List<ContactInfo>
        {
            new ContactInfo
            {
                ContactId = 1,
                FirstName = "Ravi",
                LastName = "Kumar",
                EmailId = "ravi@example.com",
                MobileNo = 9876543210,
                Designation = "Software Engineer",
                CompanyId = 101,
                DepartmentId = 1
            },
            new ContactInfo
            {
                ContactId = 2,
                FirstName = "Priya",
                LastName = "Sharma",
                EmailId = "priya@example.com",
                MobileNo = 9123456780,
                Designation = "HR Executive",
                CompanyId = 102,
                DepartmentId = 2
            }
        };

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);
            return contact;
        }

        public ContactInfo AddContact(ContactInfo contact)
        {
            //int newId = contacts.Any() ? contacts.Max(c => c.ContactId) + 1 : 1;
            //contact.ContactId = newId;

            contacts.Add(contact);

            return contact;
        }

        public bool UpdateContact(int id, ContactInfo updatedContact)
        {
            var existingContact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (existingContact == null)
            {
                return false;
            }
            else
            {
                existingContact.FirstName = updatedContact.FirstName;
                existingContact.LastName = updatedContact.LastName;
                existingContact.EmailId = updatedContact.EmailId;
                existingContact.MobileNo = updatedContact.MobileNo;
                existingContact.Designation = updatedContact.Designation;
                existingContact.CompanyId = updatedContact.CompanyId;
                existingContact.DepartmentId = updatedContact.DepartmentId;

                return true;
            }
        }

        public bool DeleteContact(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.ContactId == id);

            if (contact == null)
                return false;

            contacts.Remove(contact);

            return true;
        }

    }
}
