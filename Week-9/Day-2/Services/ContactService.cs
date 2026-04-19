using ContactAPI.Models;
using ContactAPI.Repositories;
using ContactAPI.DTOs;
using Microsoft.Extensions.Caching.Memory;

namespace ContactAPI.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;
        private readonly IMemoryCache _cache;

        public ContactService(IContactRepository repo, IMemoryCache cache)
        {
            _repo = repo;
            _cache = cache;
        }

        public async Task<PagedResult<Contact>> GetAll(int pageNumber, int pageSize)
        {
            string cacheKey = "contact_list";

            if (!_cache.TryGetValue(cacheKey, out List<Contact> contacts))
            {
                contacts = await _repo.GetAll();

                _cache.Set(cacheKey, contacts, TimeSpan.FromSeconds(60));
            }

            var totalRecords = contacts.Count;
            var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            var data = contacts
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResult<Contact>
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = data
            };
        }

        public async Task<Contact> GetById(int id)
        {
            string cacheKey = $"contact_{id}";

            if (!_cache.TryGetValue(cacheKey, out Contact contact))
            {
                contact = await _repo.GetById(id);

                if (contact != null)
                    _cache.Set(cacheKey, contact, TimeSpan.FromSeconds(60));
            }

            return contact;
        }
    }
}