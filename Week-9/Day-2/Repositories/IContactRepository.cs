using ContactAPI.Models;

namespace ContactAPI.Repositories
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAll();
        Task<Contact> GetById(int id);
    }
}