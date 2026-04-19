using ContactAPI.Models;
using ContactAPI.DTOs;

namespace ContactAPI.Services
{
    public interface IContactService
    {
        Task<PagedResult<Contact>> GetAll(int pageNumber, int pageSize);
        Task<Contact> GetById(int id);
    }
}