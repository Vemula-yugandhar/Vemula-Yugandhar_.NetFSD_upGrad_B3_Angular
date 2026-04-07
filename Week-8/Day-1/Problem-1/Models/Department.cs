using System.ComponentModel.DataAnnotations;

namespace Dapper_Service_and_Repository_ContactIInformation.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required]
        public string DepartmentName { get; set; } = string.Empty;

        // Navigation Property
        public List<ContactInfo> Contacts
        {
            get; set;
        }
    }
}
