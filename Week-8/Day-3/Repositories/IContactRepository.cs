using Web_API_Day_1.Models;

namespace Web_API_Day_1.Repositories
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        ContactInfo AddContact(ContactInfo contact);
        bool UpdateContact(int id, ContactInfo contact);
        bool DeleteContact(int id);
    }
}
