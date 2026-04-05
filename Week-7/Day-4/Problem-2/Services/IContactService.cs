using Entity_FrameWork_Contact_Management_Repository_service_pattern.Models;

namespace Entity_FrameWork_Contact_Management_Repository_service_pattern.Services
{
    public interface IContactService 
    {       
            public List<ContactInfo> GetAllContacts();
            public ContactInfo GetContactById(int id);
            public void AddContact(ContactInfo contact);
            public void UpdateContact(ContactInfo contact);
            public void DeleteContact(int id);

            public List<Company> GetAllCompanies();
            public List<Department> GetAllDepartments();
        
    }
}

