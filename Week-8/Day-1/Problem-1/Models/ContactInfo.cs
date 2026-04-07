using System.ComponentModel.DataAnnotations;

namespace Dapper_Service_and_Repository_ContactIInformation.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string EmailId { get; set; }

        [Required]
        public long MobileNo { get; set; }

        public string Designation { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public int DepartmentId { get; set; }

        // For JOIN display
        public string CompanyName { get; set; }
        public string DepartmentName { get; set; }
    }
}
