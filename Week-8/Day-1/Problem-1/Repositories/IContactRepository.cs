using Dapper_Service_and_Repository_ContactIInformation.Models;

namespace Dapper_Service_and_Repository_ContactIInformation.Repositories
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);

        List<Company> GetCompanies();
        List<Department> GetDepartments();

    }
}
