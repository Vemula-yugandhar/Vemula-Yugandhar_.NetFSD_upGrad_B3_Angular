using ContactAPI.Models;

namespace ContactAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private static List<Contact> contacts = new()
        {
            new Contact{ContactId=1, Name="John", Email="john@test.com", Phone="111"},
            new Contact{ContactId=2, Name="Sara", Email="sara@test.com", Phone="222"},
            new Contact{ContactId=3, Name="Mike", Email="mike@test.com", Phone="333"},
            new Contact{ContactId=4, Name="David", Email="david@test.com", Phone="444"},
            new Contact{ContactId=5, Name="Anna", Email="anna@test.com", Phone="555"},
            new Contact{ContactId=6, Name="Tom", Email="tom@test.com", Phone="666"}
        };

        public async Task<List<Contact>> GetAll()
        {
            await Task.Delay(1000); // simulate DB delay
            return contacts;
        }

        public async Task<Contact> GetById(int id)
        {
            await Task.Delay(1000);
            return contacts.FirstOrDefault(x => x.ContactId == id);
        }
    }
}