using Entity_FrameWork_Contact_Management_Repository_service_pattern.Models;

namespace Entity_FrameWork_Contact_Management_Repository_service_pattern.Repositories
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAllContacts();
        ContactInfo GetContactById(int id);
        void AddContact(ContactInfo contact);
        void UpdateContact(ContactInfo contact);
        void DeleteContact(int id);

        List<Company> GetAllCompanies();
        List<Department> GetAllDepartments();
    }
}
