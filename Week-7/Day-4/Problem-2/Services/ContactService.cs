using Entity_FrameWork_Contact_Management_Repository_service_pattern.Models;
using Entity_FrameWork_Contact_Management_Repository_service_pattern.Repositories;

namespace Entity_FrameWork_Contact_Management_Repository_service_pattern.Services
{
    public class ContactService : IContactRepository
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<ContactInfo> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        public ContactInfo GetContactById(int id)
        {
            return _contactRepository.GetContactById(id);
        }

        public void AddContact(ContactInfo contact)
        {

            _contactRepository.AddContact(contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            _contactRepository.UpdateContact(contact);
        }

        public void DeleteContact(int id)
        {
            _contactRepository.DeleteContact(id);
        }

        public List<Company> GetAllCompanies()
        {
            return _contactRepository.GetAllCompanies();
        }

        public List<Department> GetAllDepartments()
        {
            return _contactRepository.GetAllDepartments();
        }
    }
}
