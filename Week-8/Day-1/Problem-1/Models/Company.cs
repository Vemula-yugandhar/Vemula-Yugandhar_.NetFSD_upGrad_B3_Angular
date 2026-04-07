using System.ComponentModel.DataAnnotations;

namespace Dapper_Service_and_Repository_ContactIInformation.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; } 

            // Navigation Property
            public List<ContactInfo> Contacts { get; set; }
    }
}
